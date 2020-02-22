using System;

using Foundation;
using MonkeyFinder.ViewModel;
using UIKit;
using WatchKit;

namespace MonkeyFinder.watchOS.WatchOSExtension
{
    public partial class InterfaceController : WKInterfaceController
    {
        MonkeysViewModel viewModel;
        protected InterfaceController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void Awake(NSObject context)
        {
            base.Awake(context);
            viewModel = new MonkeysViewModel();
            // Configure interface objects here.
            Console.WriteLine("{0} awake with context", this);
        }

        async partial void ButtonMonkeysClick()
        {
            var imageUrl = await viewModel.GetRandomMonkey();

            if (string.IsNullOrWhiteSpace(imageUrl))
                return;

            var url = NSUrl.FromString(imageUrl);

            var urlRequest = NSMutableUrlRequest.FromUrl(url);
            var session = NSUrlSession.SharedSession;
            var info = await session.CreateDataTaskAsync(urlRequest);
            var data = info.Data;
            if (data == null)
                return;

            //var data = NSData.FromUrl(url);
            var image = UIImage.LoadFromData(data);

            BeginInvokeOnMainThread(() =>
            {

                ImageMonkey.SetImage(image);
            });
        }

        public override void WillActivate()
        {
            // This method is called when the watch view controller is about to be visible to the user.
            Console.WriteLine("{0} will activate", this);
        }

        public override void DidDeactivate()
        {
            // This method is called when the watch view controller is no longer visible to the user.
            Console.WriteLine("{0} did deactivate", this);
        }
    }
}


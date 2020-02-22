using System;
using Foundation;
using UIKit;
using SDWebImage;
using MonkeyFinder.ViewModel;

namespace MonkeyTV
{
    public partial class ViewController : UIViewController
    {

        MonkeysViewModel viewModel;
        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            viewModel = new MonkeysViewModel();
            ButtonGetMonkeys.PrimaryActionTriggered += ButtonGetMonkeys_PrimaryActionTriggered;

            // Perform any additional setup after loading the view, typically from a nib.
        }

        async private void ButtonGetMonkeys_PrimaryActionTriggered(object sender, EventArgs e)
        {
            ProgressBarMonkeys.StartAnimating();

            var image = await viewModel.GetRandomMonkey();

            if (string.IsNullOrWhiteSpace(image))
                return;
            
            ImageMonkey.SetImage(NSUrl.FromString(image));

            ProgressBarMonkeys.StopAnimating();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


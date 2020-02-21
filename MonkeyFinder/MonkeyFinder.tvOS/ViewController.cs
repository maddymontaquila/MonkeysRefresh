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
        Random random = new Random();
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
            if (viewModel.Monkeys.Count == 0)
                await viewModel.GetMonkeysAsync();

            if (viewModel.Monkeys.Count == 0)
                return;

            var next = random.Next(0, viewModel.Monkeys.Count);
            var url = NSUrl.FromString(viewModel.Monkeys[next].Image);

            ImageMonkey.SetImage(url);

            ProgressBarMonkeys.StopAnimating();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


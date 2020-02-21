// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MonkeyTV
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton ButtonGetMonkeys { get; set; }

		[Outlet]
		UIKit.UIImageView ImageMonkey { get; set; }

		[Outlet]
		UIKit.UIActivityIndicatorView ProgressBarMonkeys { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ButtonGetMonkeys != null) {
				ButtonGetMonkeys.Dispose ();
				ButtonGetMonkeys = null;
			}

			if (ProgressBarMonkeys != null) {
				ProgressBarMonkeys.Dispose ();
				ProgressBarMonkeys = null;
			}

			if (ImageMonkey != null) {
				ImageMonkey.Dispose ();
				ImageMonkey = null;
			}
		}
	}
}

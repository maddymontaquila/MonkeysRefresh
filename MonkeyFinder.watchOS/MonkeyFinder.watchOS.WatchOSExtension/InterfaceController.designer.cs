// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MonkeyFinder.watchOS.WatchOSExtension
{
	[Register ("InterfaceController")]
	partial class InterfaceController
	{
		[Outlet]
		WatchKit.WKInterfaceButton ButtonGetMonkeys { get; set; }

		[Outlet]
		WatchKit.WKInterfaceImage ImageMonkey { get; set; }

		[Action ("ButtonMonkeysClick")]
		partial void ButtonMonkeysClick ();
		
		void ReleaseDesignerOutlets ()
		{
			if (ButtonGetMonkeys != null) {
				ButtonGetMonkeys.Dispose ();
				ButtonGetMonkeys = null;
			}

			if (ImageMonkey != null) {
				ImageMonkey.Dispose ();
				ImageMonkey = null;
			}
		}
	}
}

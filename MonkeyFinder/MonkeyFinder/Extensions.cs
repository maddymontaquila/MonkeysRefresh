using System;

using Xamarin.Forms;

namespace MonkeyFinder
{
	static class Extensions
	{
		public static CollectionView OnSelectionChanged (this CollectionView view, EventHandler<SelectionChangedEventArgs> handler)
		{
			view.SelectionChanged += handler;
			return view;
		}

		public static Label FontSize (this Label label, NamedSize namedSize)
		{
			label.FontSize = Device.GetNamedSize (namedSize, label);
			return label;
		}
	}
}

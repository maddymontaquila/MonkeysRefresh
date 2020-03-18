using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Markup;

using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder.View
{
	public class MainPage : ContentPage
	{
        public MainPage ()
        {
            Title = "Monkey Finder";
            BindingContext = new MonkeysViewModel ();

			Content = new Grid {
				ColumnSpacing = 5,
				RowSpacing = 0,
				BackgroundColor = Color.LightGray,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Star },
					new RowDefinition { Height = GridLength.Auto }
                },
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = GridLength.Star }
                },
				Children = {
					new RefreshView {
						IsEnabled = true,
						Margin = new Thickness (5, 5, 5, 0),
						Content = new CollectionView {
							SelectionMode = SelectionMode.Single,
							ItemsLayout = new LinearItemsLayout (ItemsLayoutOrientation.Vertical) { ItemSpacing = 5 },
							ItemTemplate = new DataTemplate (() =>
								new Frame {
									Margin = new Thickness (10, 5),
									Padding = 0,
									BackgroundColor = Color.White,
									CornerRadius = 10,
									HeightRequest = 125,
									InputTransparent = true,
									IsClippedToBounds = true,
									HasShadow = true,
									Visual = VisualMarker.Material,
									Content = new Grid {
										Padding = 0,
										ColumnSpacing = 10,
										ColumnDefinitions = {
											new ColumnDefinition { Width = 125 },
											new ColumnDefinition { Width = GridLength.Star }
										},
										Children = {
											new Image {
												Aspect = Aspect.AspectFill }
												.Bind (Image.SourceProperty, nameof (Monkey.Image)),

											new StackLayout {
												Padding = 10,
												VerticalOptions = LayoutOptions.Center,
												Children = {
													new Label ()
														.FontSize (NamedSize.Large)
														.Bind (Label.TextProperty, nameof (Monkey.Name)),

													new Label ()
														.FontSize (NamedSize.Medium)
														.Bind (Label.TextProperty, nameof (Monkey.Location))
												}
											}
											.Column (1)
										}
									}
								}
							)
						}
						.OnSelectionChanged (CollectionView_SelectionChanged)
						.Bind (CollectionView.ItemsSourceProperty, nameof (MonkeysViewModel.Monkeys))
					}
					.BindCommand (nameof (MonkeysViewModel.GetMonkeysCommand))
					.Bind (RefreshView.IsRefreshingProperty, nameof (MonkeysViewModel.IsBusy), BindingMode.OneWay)
					.ColumnSpan (2),

					new BoxView {
						BackgroundColor = Color.FromHex ("#FFC107") }
						.Row (1)
						.ColumnSpan (2),

					new Button {
						Text = "Search",
						Margin = 8,
						Style = (Style)Application.Current.Resources ["ButtonOutline"] }
						.Row (1)
						.BindCommand (nameof (MonkeysViewModel.GetMonkeysCommand))
						.Bind (IsEnabledProperty, nameof (MonkeysViewModel.IsNotBusy))
				}
            };
        }

        private async void CollectionView_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            var monkey = e.CurrentSelection.FirstOrDefault () as Monkey;
            if (monkey == null)
                return;

            await Navigation.PushAsync (new DetailsPage (monkey));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}

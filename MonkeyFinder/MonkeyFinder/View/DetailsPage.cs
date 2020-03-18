using System;

using Xamarin.Forms;
using Xamarin.Forms.Markup;

using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;

using ImageCircle.Forms.Plugin.Abstractions;

namespace MonkeyFinder
{
	public class DetailsPage : ContentPage
	{
		public DetailsPage (Monkey monkey)
		{
			Title = $"{monkey.Name} Details";
			BindingContext = new MonkeyDetailsViewModel (monkey);
			Content = new ScrollView {
				Content = new StackLayout {
					Children = {
						new Grid {
							RowDefinitions = {
								new RowDefinition { Height = 230 },
								new RowDefinition { Height = GridLength.Auto }
							},
							ColumnDefinitions = {
								new ColumnDefinition { Width = GridLength.Star },
								new ColumnDefinition { Width = GridLength.Auto },
								new ColumnDefinition { Width = GridLength.Star }
							},
							Children = {
								new MediaElement ()
									.ColumnSpan (3)
									.Bind (MediaElement.SourceProperty, $"{nameof(Monkey)}.{nameof (Monkey.Video)}"),

								new StackLayout {
									Margin = new Thickness (0, 165, 0, 0),
									Children = {
										new CircleImage {
											FillColor = Color.White,
											BorderColor = Color.White,
											BorderThickness = 2,
											VerticalOptions = LayoutOptions.Center,
											HeightRequest = 100,
											WidthRequest = 100,
											Aspect = Aspect.AspectFill
											}
											.Bind (CircleImage.SourceProperty, $"{nameof(Monkey)}.{nameof (Monkey.Image)}")
									}
								}
								.RowSpan (2)
								.Column (1),

								new Label {
									FontSize = 11,
									HorizontalOptions = LayoutOptions.Center,
									Margin = 10 }
									.Row (1)
									.Bind (Label.TextProperty, $"{nameof(Monkey)}.{nameof (Monkey.Location)}"),

								new Label {
									FontSize = 11,
									HorizontalOptions = LayoutOptions.Center,
									Margin = 10 }
									.Row (1)
									.Column (2)
									.Bind (Label.TextProperty, $"{nameof(Monkey)}.{nameof (Monkey.Population)}"),
							}
						}, // Grid

						new Label {
							FontSize = 16,
							HorizontalOptions = LayoutOptions.Center,
							FontAttributes = FontAttributes.Bold }
							.Bind (Label.TextProperty, $"{nameof(Monkey)}.{nameof (Monkey.Name)}"),

						new Button {
							Text = "Show on Map",
							HorizontalOptions = LayoutOptions.Center,
							WidthRequest = 200,
							Style = (Style)App.Current.Resources ["ButtonOutline"],
							Margin = 8 }
							.BindCommand (nameof (MonkeyDetailsViewModel.OpenMapCommand)),

						new BoxView {
							HeightRequest = 1,
							Color = Color.FromHex ("#DDDDDD") },

						new Label { Margin = 10 }
							.Bind (Label.TextProperty, $"{nameof(Monkey)}.{nameof (Monkey.Details)}")
					}
				}
			};
		}
	}
}

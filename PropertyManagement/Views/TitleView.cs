using System;
using PropertyManagement.Components;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Views
{
	public class TitleView : StackLayout
	{
		public TitleView(string title)
		{
			Children.Add(GetTitleLabel(title));
			HorizontalOptions = LayoutOptions.FillAndExpand;
			Orientation = StackOrientation.Horizontal;
			Padding = new Thickness(0, 30, 0, 5);
		}

		public TitleView(string title, Action backAction)
		{
			var exitIcon = new Image
			{
				Source = ImageSource.FromFile("cancel_white"),
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 15,
				WidthRequest = 15
			};

			var exitIconTapGestureRecognizer = new TapGestureRecognizer();
			exitIconTapGestureRecognizer.Tapped += (sender, e) => { backAction(); };
			exitIcon.GestureRecognizers.Add(exitIconTapGestureRecognizer);

			var titleLabel = GetTitleLabel(title);

			var titlePlaceholder = new BoxView { WidthRequest = 15 };

			Children.Add(exitIcon);
			Children.Add(titleLabel); 
			Children.Add(titlePlaceholder);
			HorizontalOptions = LayoutOptions.FillAndExpand;
			HeightRequest = 50;
			Orientation = StackOrientation.Horizontal;
			Padding = 20;
		}

		private Label GetTitleLabel(string title)
		{
			return new ExtendedLabel
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 25,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				ShadowColor = Color.Black,
				ShadowBlurRadius = 1.4,
				ShadowOffsetX = 0.3,
				ShadowOffsetY = 0.8,
				Text = title
			};
		}
	}
}
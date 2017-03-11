using PropertyManagement.Components;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Views
{
	public class TitleView : StackLayout
	{
		public TitleView(string title)
		{
			var label = new ExtendedLabel
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

			Children.Add(label);
			HorizontalOptions = LayoutOptions.FillAndExpand;
			Orientation = StackOrientation.Horizontal;
			Padding = new Thickness(0, 30, 0, 5);
		}
	}
}
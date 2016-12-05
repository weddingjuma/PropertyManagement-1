using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class LandingPage : BasePage<LandingController>
	{
		public LandingPage(LandingController controller) : base(controller)
		{
			BackgroundImage = "apartment_1.jpg";
			BackgroundGradientStartColor = Color.Red;
			BackgroundGradientEndColor = Color.Blue;

			var logoImage = new Image
			{
				Source = ImageSource.FromFile("logo_white.png"),
				Aspect = Aspect.AspectFit,
				HeightRequest = 40
			};

			var logoImageLayout = new StackLayout
			{
				Children = { logoImage },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, 70, 0, 0)
			};

			var appDescriptionLargeLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 35,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "The best way to find, apply for, and manage your new home!"
			};

			var appDescriptionSmallLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Find a new home, pay rent, see what's happening in the community, and much more."
			};

			var appDescriptionLayout = new StackLayout
			{
				Children = { appDescriptionLargeLabel, appDescriptionSmallLabel },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 20,
				Padding = new Thickness(25, 0, 25, 0)
			};

			var logInButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Log In"
			};

			var registerButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Register"
			};

			var buttonsDivider = new BoxView
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.FillAndExpand,
				WidthRequest = 1
			};

			var buttonsLayout = new StackLayout
			{
				Children = { logInButton, buttonsDivider, registerButton },
				Spacing = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End
			};

			Content = new StackLayout
			{
				Children = { logoImageLayout, appDescriptionLayout, buttonsLayout },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};
		}
	}
}
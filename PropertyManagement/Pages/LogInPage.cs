using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class LogInPage : BasePage<LogInController>
	{
		public LogInPage(LogInController controller) : base(controller)
		{
			BackgroundImage = "apartment_1.jpg";
			BackgroundGradientStartColor = Color.Green;
			BackgroundGradientEndColor = Color.Blue;

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
			exitIconTapGestureRecognizer.Tapped += Controller.OnExitIconTapped;
			exitIcon.GestureRecognizers.Add(exitIconTapGestureRecognizer);

			var titleLabel = new ExtendedLabel
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,
				FontFamily = ApplicationSettings.ThinFontFamily,
				FontSize = 20,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				ShadowColor = Color.Black,
				ShadowBlurRadius = 1.4,
				ShadowOffsetX = 0.3,
				ShadowOffsetY = 0.8,
				Text = "Log In"
			};

			var titlePlaceholder = new BoxView { WidthRequest = 15 };

			var titleLayout = new StackLayout
			{
				Children = { exitIcon, titleLabel, titlePlaceholder },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 50,
				Orientation = StackOrientation.Horizontal,
				Padding = 20
			};

			var emailEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Email"
			};

			var entryDivider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			var passwordEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Password",
				IsPassword = true
			};

			var entryLayout = new StackLayout
			{
				Children = { emailEntry, entryDivider, passwordEntry },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = new Thickness(20, 20, 20, 0)
			};

			var credentialsBackgroundFrame = new ExtendedFrame
			{
				Content = entryLayout,
				OutlineColor = Color.White,
				ActualBackgroundColor = Color.White,
				HasShadow = false,
				CornerRadius = 2,
				BorderWidth = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = 0
			};

			var credentialsIcon = new Image
			{
				Source = ImageSource.FromFile("cloud_key_white"),
				Aspect = Aspect.AspectFit,
				HeightRequest = 50,
				WidthRequest = 50
			};

			var credentialsIconFrame = new ExtendedFrame
			{
				Content = credentialsIcon,
				OutlineColor = Color.Orange,
				ActualBackgroundColor = Color.Orange,
				HasShadow = false,
				CornerRadius = 30,
				BorderWidth = 0,
				HeightRequest = 70,
				WidthRequest = 70,
				ShadowColor = Color.Black,
				ShadowOpacity = 0.3,
				ShadowBlurRadius = 1,
				ShadowOffsetX = 0,
				ShadowOffsetY = 0,
			};

			var credentialsLayout = new RelativeLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 168
			};

			credentialsLayout.Children.Add(
				credentialsBackgroundFrame,
				Constraint.Constant(25),
				Constraint.Constant(30),
				Constraint.RelativeToParent(parent => { return parent.Width - 50; }),
				Constraint.Constant(138)
			);

			credentialsLayout.Children.Add(
				credentialsIconFrame,
				Constraint.RelativeToParent(parent => { return parent.Width / 2 - 30; }),
				Constraint.Constant(0),
				Constraint.Constant(60),
				Constraint.Constant(60)
			);

			var forgotPasswordLabel = new ExtendedLabel
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 30,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 14,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Forgot Password?"
			};

			var logInButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Log In"
			};
			logInButton.Clicked += Controller.OnLogInButtonTapped;

			Content = new StackLayout
			{
				Children = { titleLayout, credentialsLayout, forgotPasswordLabel, logInButton },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};
		}
	}
}
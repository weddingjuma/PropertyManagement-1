using System;
using PropertyManagement.Cells;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class CommunityPage : BasePage<CommunityController>
	{
		public CommunityPage(CommunityController controller) : base(controller)
		{
			Title = "Community";
			DefaultIconImage = "community_white.png";
			SelectedIconImage = "community_white_selected.png";
			BackgroundGradientStartColor = Color.Red;
			BackgroundGradientEndColor = Color.Blue;

			var titleView = new TitleView(Title);

			var postEditor = new Editor
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				//PlaceholderColor = Color.FromHex("bdc3c7"),
				//Placeholder = "Email"
			};

			var editorLayout = new StackLayout
			{
				Children = { postEditor },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = new Thickness(20, 20, 20, 0)
			};

			var editorBackgroundFrame = new ExtendedFrame
			{
				Content = editorLayout,
				OutlineColor = Color.White,
				ActualBackgroundColor = Color.White,
				HasShadow = false,
				CornerRadius = 2,
				BorderWidth = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = 0
			};

			var profileImage = new Image
			{
				Source = ImageSource.FromFile("test_user.jpeg"),
				Aspect = Aspect.AspectFill,
				HeightRequest = 70,
				WidthRequest = 70
			};

			var profileImageFrame = new ExtendedFrame
			{
				Content = profileImage,
				Padding = 0,
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

			var placeholderLabel = new Label
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				Text = "Write a new post..."
			};

			var credentialsLayout = new RelativeLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 108
			};

			credentialsLayout.Children.Add(
				editorBackgroundFrame,
				Constraint.Constant(0),
				Constraint.Constant(30),
				Constraint.RelativeToParent(parent => { return parent.Width; }),
				Constraint.Constant(88)
			);

			credentialsLayout.Children.Add(
				profileImageFrame,
				Constraint.RelativeToParent(parent => { return parent.Width / 2 - 30; }),
				Constraint.Constant(0),
				Constraint.Constant(60),
				Constraint.Constant(60)
			);

			credentialsLayout.Children.Add(
				placeholderLabel,
				Constraint.Constant(20),
				Constraint.Constant(50),
				Constraint.RelativeToParent(parent => { return parent.Width; }),
				Constraint.Constant(68)
			);

			var postButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Submit New Post"
			};
			//postButton.Clicked += Controller.OnLogInButtonTapped;

			var buttonLayout = new StackLayout
			{
				Children = { postButton },
				Padding = new Thickness(0, 20, 0, 15)
			};

			var subTitleIconImage = new Image
			{
				Source = ImageSource.FromFile("community_white"),
				Aspect = Aspect.AspectFit,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 25,
				WidthRequest = 25
			};

			var subTitleLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				Text = "Recent Posts"
			};

			var subTitleLayout = new StackLayout
			{
				Children = { subTitleIconImage, subTitleLabel },
				Orientation = StackOrientation.Horizontal,
				Spacing = 10,
				Padding = new Thickness(0, 0, 0, 10)
			};

			var headerLayout = new StackLayout
			{
				Children = { credentialsLayout, buttonLayout, subTitleLayout },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};

			var listView = new ListView(ListViewCachingStrategy.RecycleElement)
			{
				ItemsSource = Controller.Posts,
				ItemTemplate = new DataTemplate(typeof(PostCell)),
				HasUnevenRows = true,
				SeparatorVisibility = SeparatorVisibility.None,
				BackgroundColor = Color.Transparent,
				Header = headerLayout
			};

			var listViewLayout = new StackLayout
			{
				Children = { listView },
				Padding = new Thickness(25, 10, 25, 0)
			};

			Content = new StackLayout
			{
				Children = { titleView, listViewLayout },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = 0
			};
		}
	}
}
using System;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class MyHomePage : BasePage<MyHomeController>
	{
		public MyHomePage(MyHomeController controller) : base(controller)
		{
			Title = "My Home";
			DefaultIconImage = "myhome_white.png";
			SelectedIconImage = "myhome_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("ee0979");
			BackgroundGradientEndColor = Color.FromHex("ff6a00");

			var titleView = new TitleView(Title);

			var nameDetailLayout = GetDetailItemLayout("Name", $"{ApplicationContext.User.FirstName} {ApplicationContext.User.LastName}");
			var unitDetailLayout = GetDetailItemLayout("Unit", ApplicationContext.User.Unit);
			var rentDetailLayout = GetDetailItemLayout("Rent", $"$600");
			var dueDateDetailLayout = GetDetailItemLayout("Due Date", DateTime.Now.AddDays(8).ToString("M"));
			var leaseDetailLayout = GetDetailItemLayout("Lease", $"{ApplicationContext.User.LeaseMonths} month(s)");
			var statusDetailLayout = GetDetailItemLayout("Status", "Current");
			var detailRowLayout1 = GetDetailRowLayout(nameDetailLayout, unitDetailLayout);
			var detailRowLayout2 = GetDetailRowLayout(rentDetailLayout, dueDateDetailLayout);
			var detailRowLayout3 = GetDetailRowLayout(leaseDetailLayout, statusDetailLayout);

			var editorLayout = new StackLayout
			{
				Children = { detailRowLayout1, detailRowLayout2, detailRowLayout3 },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = new Thickness(20, 40, 20, 0)
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
				ShadowOffsetY = 0
			};

			var informationLayout = new RelativeLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 260
			};

			informationLayout.Children.Add(
				editorBackgroundFrame,
				Constraint.Constant(0),
				Constraint.Constant(45),
				Constraint.RelativeToParent(parent => { return parent.Width; }),
				Constraint.Constant(205)
			);

			informationLayout.Children.Add(
				profileImageFrame,
				Constraint.RelativeToParent(parent => { return parent.Width / 2 - 30; }),
				Constraint.Constant(15),
				Constraint.Constant(60),
				Constraint.Constant(60)
			);

			var paymentButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Make A Payment"
			};
			//paymentButton.Clicked += Controller.OnLogInButtonTapped;

			var historyButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "View Payment History"
			};
			//historyButton.Clicked += Controller.OnLogInButtonTapped;

			var contactButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Contact Office"
			};
			//contactButton.Clicked += Controller.OnLogInButtonTapped;

			var serviceButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Request Service"
			};
			//serviceButton.Clicked += Controller.OnLogInButtonTapped;

			var buttonLayout = new StackLayout
			{
				Children = { paymentButton, historyButton, contactButton, serviceButton },
				Spacing = 10,
				Padding = new Thickness(0, 0, 0, 15)
			};

			Content = new StackLayout
			{
				Children = { 
					titleView, 
					new ScrollView
					{
						Content = new StackLayout { Children = { informationLayout, buttonLayout }, Spacing = 0, Padding = new Thickness(25, 0) }
					}
				},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};
		}

		private StackLayout GetDetailItemLayout(string name, string value)
		{
			return new StackLayout
			{
				Children = 
				{ 
					new Label
					{
						FontFamily = ApplicationSettings.RegularFontFamily,
						FontSize = 15,
						TextColor = Color.FromHex("7f8c8d"),
						Text = name
					},
					new Label
					{
						FontFamily = ApplicationSettings.ThinFontFamily,
						FontSize = 20,
						TextColor = Color.FromHex("282830"),
						Text = value
					}
				},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};
		}

		private Grid GetDetailRowLayout(StackLayout firstItemLayout, StackLayout secondItemLayout)
		{
			var grid = new Grid();
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)});
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)});
			grid.Children.Add(firstItemLayout, 0, 0);
			grid.Children.Add(secondItemLayout, 1, 0);
			return grid;
		}
	}
}
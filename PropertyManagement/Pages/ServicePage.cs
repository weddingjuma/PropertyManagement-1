using System;
using PropertyManagement.Cells;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class ServicePage : BasePage<ServiceController>
	{
		public ExtendedEditor DescriptionEntry { get; set; }
		public ExtendedPicker TypePicker { get; set; }

		public ServicePage(ServiceController controller) : base(controller)
		{
			Title = "Service";
			DefaultIconImage = "settings_white.png";
			SelectedIconImage = "settings_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("42275a");
			BackgroundGradientEndColor = Color.FromHex("42275a");

			var titleView = new TitleView(Title);

			DescriptionEntry = new ExtendedEditor
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				//PlaceholderColor = Color.FromHex("bdc3c7"),
				//Placeholder = "Description"
			};

			TypePicker = new ExtendedPicker
			{
				HeightRequest = 50,
				Margin = new Thickness(0, 5),
				FontSize = 15,
				BackgroundColor = Color.Transparent,
				TextColor = Color.FromHex("7f8c8d"),
				Title = "Select Type"
			};

			foreach (string type in controller.Types.Keys)
			{
				TypePicker.Items.Add(type);
			}

			var entryLayout = new StackLayout
			{
				Children = { DescriptionEntry, TypePicker },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = new Thickness(20, 20, 20, 20)

			};

			var formBackgroundFrame = new ExtendedFrame
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

			var formIcon = new Image
			{
				Source = ImageSource.FromFile("settings_white"),
				Aspect = Aspect.AspectFit,
				HeightRequest = 50,
				WidthRequest = 50
			};

			var formIconFrame = new ExtendedFrame
			{
				Content = formIcon,
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

			var placeholderLabel = new Label
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				Text = "What is the problem?"
			};

			var formLayout = new RelativeLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 180
			};

			formLayout.Children.Add(
				formBackgroundFrame,
				Constraint.Constant(0),
				Constraint.Constant(30),
				Constraint.RelativeToParent(parent => { return parent.Width; }),
				Constraint.Constant(160)
			);

			formLayout.Children.Add(
				formIconFrame,
				Constraint.RelativeToParent(parent => { return parent.Width / 2 - 30; }),
				Constraint.Constant(0),
				Constraint.Constant(60),
				Constraint.Constant(60)
			);

			formLayout.Children.Add(
				placeholderLabel,
				Constraint.Constant(25),
				Constraint.Constant(65),
				Constraint.RelativeToParent(parent => { return parent.Width; }),
				Constraint.Constant(68)
			);

			var submitButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Submit Service Request"
			};
			submitButton.Clicked += Controller.OnSubmitButtonTapped;

			var buttonLayout = new StackLayout
			{
				Children = { submitButton },
				Padding = new Thickness(0, 20, 0, 15)
			};

			var subTitleIconImage = new Image
			{
				Source = ImageSource.FromFile("settings_white"),
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
				Text = "Recent Service Requests"
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
				Children = { formLayout, buttonLayout, subTitleLayout },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};

			var listView = new ListView(ListViewCachingStrategy.RecycleElement)
			{
				ItemsSource = Controller.Services,
				ItemTemplate = new DataTemplate(typeof(ServiceCell)),
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
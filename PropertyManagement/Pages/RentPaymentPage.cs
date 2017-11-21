using System;
using PropertyManagement.Cells;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class RentPaymentPage : BasePage<RentPaymentController>
	{
		public RentPaymentPage(RentPaymentController controller) : base(controller)
		{
			Title = "Rent Payment";
			DefaultIconImage = "myhome_white.png";
			SelectedIconImage = "myhome_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("ee0979");
			BackgroundGradientEndColor = Color.FromHex("ff6a00");

			var titleView = new TitleView(Title, null);

			var totalLabel = new ExtendedLabel
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontFamily = ApplicationSettings.ThinFontFamily,
				FontSize = 38,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				ShadowColor = Color.Black,
				ShadowBlurRadius = 1.4,
				ShadowOffsetX = 0.3,
				ShadowOffsetY = 0.8,
				Text = "$600.00"
			};

			var itemizedLabel = new ExtendedLabel
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				ShadowColor = Color.Black,
				ShadowBlurRadius = 1.4,
				ShadowOffsetX = 0.3,
				ShadowOffsetY = 0.8,
				Text = "Rent $500.00 · Trash $90.00 · Fees $10.00"
			};

			var dueDateLabel = new ExtendedLabel
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				HorizontalTextAlignment = TextAlignment.Center,
				ShadowColor = Color.Black,
				ShadowBlurRadius = 1.4,
				ShadowOffsetX = 0.3,
				ShadowOffsetY = 0.8,
				Text = $"Due {DateTime.Now.AddDays(8).ToString("M")}"
			};

			var breakdownLayout = new StackLayout
			{
				Children = { totalLabel, itemizedLabel, dueDateLabel },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 10,
				Padding = new Thickness(0, 20)
			};

			var postButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Add Payment Method"
			};
			postButton.Clicked += Controller.OnMethodButtonTapped;

			var buttonLayout = new StackLayout
			{
				Children = { postButton },
				Padding = new Thickness(0, 20, 0, 15)
			};

			var subTitleIconImage = new Image
			{
				Source = ImageSource.FromFile("credit_card_white"),
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
				Text = "Payment Methods"
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
				Children = { breakdownLayout, buttonLayout, subTitleLayout },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};

			var listView = new ListView(ListViewCachingStrategy.RecycleElement)
			{
				ItemsSource = Controller.PaymentMethods,
				ItemTemplate = new DataTemplate(typeof(PaymentMethodCell)),
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
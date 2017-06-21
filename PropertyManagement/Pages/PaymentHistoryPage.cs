using System;
using PropertyManagement.Cells;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class PaymentHistoryPage : BasePage<PaymentHistoryController>
	{
		public Entry HistoryEntry1 { get; set; }
		public Entry HistoryEntry2 { get; set; }
		public Entry HistoryEntry3 { get; set; }
		public Entry HistoryEntry4 { get; set; }

		public PaymentHistoryPage(PaymentHistoryController controller) : base(controller)
		{
			Title = "Payment History";
			DefaultIconImage = "myhome_white.png";
			SelectedIconImage = "myhome_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("ee0979");
			BackgroundGradientEndColor = Color.FromHex("ff6a00");

			var titleView = new TitleView(Title, Controller.BackButtonTapped);

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
				Text = "Date        ·        Method        ·        Amount"
			};

			var breakdownLayout = new StackLayout
			{
				Children = { itemizedLabel },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 10,
				Padding = new Thickness(0, 20)
			};

			HistoryEntry1 = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				Text = "04/01/2017          ************4326                $600"
			};

			var entry1Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			HistoryEntry2 = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				Text = "05/01/2017         susan@gmail.com              $600"
			};

			var entry2Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			HistoryEntry3 = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				Text = "06/01/2017           ************7898               $600"
			};

			var entry3Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			HistoryEntry4 = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				Text = "07/01/2017           ************7898               $600"
			};
			var entryLayout = new StackLayout
			{
				Children = { HistoryEntry1, entry1Divider, HistoryEntry2, entry2Divider, HistoryEntry3, entry3Divider, HistoryEntry4 },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = new Thickness(10, 10, 10, 10)
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

			var credentialsLayout = new RelativeLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 168
			};

			credentialsLayout.Children.Add(
				credentialsBackgroundFrame,
				Constraint.Constant(25),
				Constraint.Constant(30),
				Constraint.RelativeToParent(parent => { return parent.Width; }),
				Constraint.Constant(240)
			);

			Content = new StackLayout
			{
				Children = { titleView, itemizedLabel, credentialsBackgroundFrame },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10
			};

			Content = new StackLayout
			{
				Children =
				{
					titleView,
					new ScrollView
					{
						Content = new StackLayout
						{
							Children = { itemizedLabel, credentialsBackgroundFrame },
							HorizontalOptions = LayoutOptions.FillAndExpand,
							HeightRequest = 1000
						},
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand
					},

				},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};
		}
	}
}
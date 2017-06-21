using System;
using PropertyManagement.Cells;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class ContactOfficePage : BasePage<ContactOfficeController>
	{
		public Entry NameEntry { get; set; }
		public Entry EmailEntry { get; set; }
		public Entry MessageEntry { get; set; }

		public ContactOfficePage(ContactOfficeController controller) : base(controller)
		{
			Title = "Contact Office";
			DefaultIconImage = "myhome_white.png";
			SelectedIconImage = "myhome_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("ee0979");
			BackgroundGradientEndColor = Color.FromHex("ff6a00");

			var titleView = new TitleView(Title, Controller.BackButtonTapped);

			var HoursLabel = new ExtendedLabel
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

				Text = "M-F: 9:00 a - 7:00 p   |   S: 10:00 a - 5:00 p   " +
					"Su: Closed"
			};

			var entry1Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			var NameLabel = new ExtendedLabel
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
				Text = "The Palms Apartments"
			};


			var entry2Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			var AddressLabel = new ExtendedLabel
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
				Text = "123 Sesame Street Columbus, GA 31903"

			};

			var entry3Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			var PhoneLabel = new ExtendedLabel
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
				Text = "p: (706)555-1234  |  f: (706)555-5678"
			};


			var entry4Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			var EmailLabel = new ExtendedLabel
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
				Text = "Email Us"
			};

			var entryLayout = new StackLayout
			{
				Children = { HoursLabel, entry1Divider, NameLabel, entry2Divider, AddressLabel, entry3Divider, PhoneLabel,
					entry4Divider, EmailLabel },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 15,
				Padding = new Thickness(10, 10, 10, 10)
			};

			NameEntry = new ExtendedEntry
			{
				HeightRequest = 20,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter Name"
			};

			var Divider1 = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			EmailEntry = new ExtendedEntry
			{
				HeightRequest = 20,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Email"
			};

			var Divider2 = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			MessageEntry = new ExtendedEntry
			{
				HeightRequest = 75,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Type Message Here"
			};

			var entryLayout2 = new StackLayout
			{
				Children = { NameEntry, Divider1, EmailEntry, Divider2, MessageEntry },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = new Thickness(10, 10, 10, 0)
			};

			var credentialsBackgroundFrame = new ExtendedFrame
			{
				Content = entryLayout2,
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
				HeightRequest = 150
			};

			credentialsLayout.Children.Add(
				credentialsBackgroundFrame,
				Constraint.Constant(25),
				Constraint.Constant(30),
				Constraint.RelativeToParent(parent => { return parent.Width; }),
				Constraint.Constant(125)
			);

			Content = new StackLayout
			{
				Children = { titleView, entryLayout, credentialsBackgroundFrame },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};

			var submitButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Submit"
			};
			//registerButton.Clicked += Controller.OnRegisterButtonTapped;
			Content = new StackLayout
			{
				Children =
				{
					titleView,
					new ScrollView
					{
						Content = new StackLayout
						{
							Children = { entryLayout, credentialsBackgroundFrame },
							HorizontalOptions = LayoutOptions.FillAndExpand,
							HeightRequest = 1000
						},
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand
					},
					submitButton
				},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};
		}
	}
}
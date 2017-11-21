using System;
using PropertyManagement.Cells;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class PaymentMethodPage : BasePage<PaymentMethodController>
	{
		public Entry CardEntry { get; set; }
		public Entry CSCEntry { get; set; }
		public DatePicker ExpirationPicker { get; set; }
		public Entry NameEntry1 { get; set; }
		public Entry NameEntry2 { get; set; }
		public Entry AddressEntry1 { get; set; }
		public Entry AddressEntry2 { get; set; }
		public Entry CityEntry { get; set; }
		public Picker StatePicker { get; set; }
		public Entry ZipEntry { get; set; }
		public Entry PhoneEntry { get; set; }
		public Entry EmailEntry { get; set; }

		public PaymentMethodPage(PaymentMethodController controller) : base(controller)
		{
			Title = "Add Payment Method";
			DefaultIconImage = "myhome_white.png";
			SelectedIconImage = "myhome_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("ee0979");
			BackgroundGradientEndColor = Color.FromHex("ff6a00");

			var titleView = new TitleView(Title, null);

			CardEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter Card Number"
			};

			var entry1Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			CSCEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter your 3 digit CSC"
			};

			var entry2Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			ExpirationPicker = new ExtendedDatePicker
			{
				HeightRequest = 50,
				Margin = new Thickness(0, 5),
				FontSize = 15,
				MinimumDate = DateTime.Today.AddDays (-7),
				MaximumDate = DateTime.Today.AddYears (20),
				Format = "MM/yyyy",
				BackgroundColor = Color.Transparent,
				TextColor = Color.FromHex("7f8c8d")
			};

			var entry3Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			NameEntry1 = new ExtendedEntry
			{
				HeightRequest = 40,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter First Name"
			};

			NameEntry2 = new ExtendedEntry
			{
				HeightRequest = 40,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter Last Name"
			};

			var entry4Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			AddressEntry1 = new ExtendedEntry
			{
				HeightRequest = 40,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Address Line 1"
			};

			AddressEntry2 = new ExtendedEntry
			{
				HeightRequest = 40,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Address Line 2"
			};

			CityEntry = new ExtendedEntry
			{
				HeightRequest = 40,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter City "
			};

			ZipEntry = new ExtendedEntry
			{
				HeightRequest = 40,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter Zip Code "
			};

			StatePicker = new ExtendedPicker
			{
				HeightRequest = 50,
				Margin = new Thickness(0, 5),
				FontSize = 15,
				BackgroundColor = Color.Transparent,
				TextColor = Color.FromHex("7f8c8d"),
				Title = "Select State"
			};

			foreach (string state in controller.States.Keys)
			{
				StatePicker.Items.Add(state);
			}

			var entry5Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			PhoneEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter Phone Number"
			};

			var entry6Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			EmailEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Enter Email Address"
			};

			var entryLayout = new StackLayout
			{
				Children = { CardEntry, entry1Divider, CSCEntry, entry2Divider, ExpirationPicker, entry3Divider, NameEntry1, 
					NameEntry2, entry4Divider, AddressEntry1, AddressEntry2, CityEntry, ZipEntry, 
					StatePicker, entry5Divider, PhoneEntry, entry6Divider, EmailEntry },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = new Thickness(20, 20, 20, 20)
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
	Source = ImageSource.FromFile("credit_card_white"),
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
				Constraint.Constant(620)
			);

			credentialsLayout.Children.Add(
				credentialsIconFrame,
				Constraint.RelativeToParent(parent => { return parent.Width / 2 - 30; }),
				Constraint.Constant(0),
				Constraint.Constant(60),
				Constraint.Constant(60)
			);

			var saveButton = new Button
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 55,
				BorderRadius = 0,
				FontFamily = ApplicationSettings.BoldFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				BackgroundColor = Color.Black.MultiplyAlpha(0.2),
				Text = "Save"
			};

			saveButton.Clicked += Controller.OnSaveButtonTapped;

			Content = new StackLayout
			{
				Children = 
				{ 
					titleView,
					new ScrollView 
					{
						Content = new StackLayout
						{
							Children = { credentialsLayout, saveButton },
							HorizontalOptions = LayoutOptions.FillAndExpand,
							HeightRequest = 800,
							Spacing = 10
						},
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand
					}
				},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = 0
			};
		}
	}
}
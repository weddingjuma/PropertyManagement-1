using System;
using System.Linq;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class SettingsPage : BasePage<SettingsController>
	{
		public Entry EmailAddressEntry { get; set; }
		public Entry PhoneNumberEntry { get; set; }
		public Entry PasswordEntry { get; set; }
		public Entry PasswordConfirmEntry { get; set; }
		public Entry FirstNameEntry { get; set; }
		public Entry LastNameEntry { get; set; }
		public Entry UnitEntry { get; set; }
		public Entry RentEntry { get; set; }
		public Picker PropertyPicker { get; set; }
		public Picker LeaseMonthsPicker { get; set; }
		public DatePicker DueDatePicker { get; set; }

		public SettingsPage(SettingsController controller) : base(controller)
		{
			Title = "Settings";
			DefaultIconImage = "settings_white.png";
			SelectedIconImage = "settings_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("42275a");
			BackgroundGradientEndColor = Color.FromHex("42275a");

			var titleView = new TitleView(Title, null);

			FirstNameEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "First Name",
				Text = ApplicationContext.User.FirstName
			};

			var entry1Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			LastNameEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Last Name",
				Text = ApplicationContext.User.LastName
			};

			var entry2Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			EmailAddressEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Email",
				Text = ApplicationContext.User.EmailAddress
			};

			var entry3Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			PhoneNumberEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Phone Number",
				Text = ApplicationContext.User.PhoneNumber
			};

			var entry4Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			PasswordEntry = new ExtendedEntry
			{
				IsPassword = true,
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Password",
				Text = ApplicationContext.User.Password
			};

			var entry5Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			PasswordConfirmEntry = new ExtendedEntry
			{
				IsPassword = true,
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Password (confirm)"
			};

			var entry6Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			UnitEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Unit Number",
				Text = ApplicationContext.User.Unit
			};

			var entry7Divider = new BoxView
			{
				BackgroundColor = Color.FromHex("f5f5f5"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 1
			};

			RentEntry = new ExtendedEntry
			{
				HeightRequest = 50,
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d"),
				PlaceholderColor = Color.FromHex("bdc3c7"),
				Placeholder = "Rent Amount"
			};

			PropertyPicker = new ExtendedPicker
			{
				HeightRequest = 50,
				Margin = new Thickness(0, 5),
				FontSize = 15,
				BackgroundColor = Color.Transparent,
				TextColor = Color.FromHex("7f8c8d"),
				Title = "Select Property"
			};

			foreach (string property in controller.Properties.Keys)
			{
				PropertyPicker.Items.Add(property);
			}

			LeaseMonthsPicker = new ExtendedPicker
			{
				HeightRequest = 50,
				Margin = new Thickness(0, 5),
				FontSize = 15,
				BackgroundColor = Color.Transparent,
				TextColor = Color.FromHex("7f8c8d"),
				Title = "Select Lease Term"
			};

			foreach (string leaseMonth in controller.LeaseMonths.Keys)
			{
				LeaseMonthsPicker.Items.Add(leaseMonth);
			}

			DueDatePicker = new ExtendedDatePicker
			{
				HeightRequest = 50,
				Margin = new Thickness(0, 5),
				FontSize = 15,
				Format = "D",
				BackgroundColor = Color.Transparent,
				TextColor = Color.FromHex("7f8c8d")
			};

			var entryLayout = new StackLayout
			{
				Children = { FirstNameEntry, entry1Divider, LastNameEntry, entry2Divider, EmailAddressEntry, entry3Divider,
					PhoneNumberEntry, entry4Divider, PasswordEntry, entry5Divider, PasswordConfirmEntry, entry6Divider,
					UnitEntry, entry7Divider, RentEntry, PropertyPicker, LeaseMonthsPicker, DueDatePicker },
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
				Constraint.Constant(660)
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
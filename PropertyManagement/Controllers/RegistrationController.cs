using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Acr.UserDialogs;
using PropertyManagement.Components;
using PropertyManagement.Models;
using PropertyManagement.Pages;
using Xamarin.Forms;

namespace PropertyManagement.Controllers
{
	public class RegistrationController : BaseController<RegistrationPage>
	{
		public Dictionary<string, int> Properties { get; set; } = new Dictionary<string, int>
		{
			{ "The Palms Apartments", 1 }, { "LullWater Apartments", 2 }, { "Suger Mill Luxury Apartments", 3 }
		};

		public Dictionary<string, int> LeaseMonths { get; set; } = new Dictionary<string, int>
		{
			{ "6 Months", 6 }, { "9 Months", 9 }, { "12 Months", 12 }
		};

		private bool IsValid { get; set; }
		private string ErrorMessage { get; set; }

		public RegistrationController() : base()
		{
			Page = new RegistrationPage(this);
		}

		public void OnExitIconTapped(object sender, EventArgs e)
		{
			Page.Navigation.PopModalAsync();
		}

		public void OnRegisterButtonTapped(object sender, EventArgs e)
		{
            SetValidationState();

			if (IsValid)
			{
				Task.Run(async() =>
				{
					UserDialogs.Instance.ShowLoading("Registering..", MaskType.Gradient);
					var response = await UserActions.Register(new RegisterRequestModel
					{
						Type = UserType.Tenant, // TODO: allow regitration of multiple user types
						EmailAddress = Page.EmailAddressEntry.Text,
						PhoneNumber = Page.PhoneNumberEntry.Text,
						Password = Page.PasswordEntry.Text,
						FirstName = Page.FirstNameEntry.Text,
						LastName = Page.LastNameEntry.Text,
						PropertyId = Properties[Page.PropertyPicker.Items[Page.PropertyPicker.SelectedIndex]],
						Unit = Page.UnitEntry.Text,
						LeaseMonths = LeaseMonths[Page.LeaseMonthsPicker.Items[Page.LeaseMonthsPicker.SelectedIndex]],
					});
					if (response.Success)
					{
						ApplicationContext.InitializeControllers();
						Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = ApplicationContext.MainController.Page);
					}
					else
					{
						Device.BeginInvokeOnMainThread(() => Page.DisplayAlert(string.Empty, response.ErrorMessage, "OK"));
					}
					UserDialogs.Instance.HideLoading();
				});
			}
			else
			{
				Page.DisplayAlert(string.Empty, ErrorMessage, "OK");
			}
		}

		private void SetValidationState()
		{
			ErrorMessage = string.Empty;

			if (string.IsNullOrWhiteSpace(Page.EmailAddressEntry.Text) && string.IsNullOrWhiteSpace(Page.PhoneNumberEntry.Text))
			{
				ErrorMessage = "Either an email address or phone number must be entered. Please try again.\n";
			}

			if (!string.IsNullOrWhiteSpace(Page.EmailAddressEntry.Text) && !Regex.IsMatch(Page.EmailAddressEntry.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
			{
				ErrorMessage += "The entered email address was invalid. Please try again.\n";
			}

			if (!string.IsNullOrWhiteSpace(Page.PhoneNumberEntry.Text) && !Regex.Match(Page.PhoneNumberEntry.Text, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success)
			{
				ErrorMessage += "The entered phone number was invalid. Please try again.\n";
			}

			if (string.IsNullOrWhiteSpace(Page.PasswordEntry.Text) || Page.PasswordEntry.Text.Length < 8 || Page.PasswordEntry.Text.Length > 20)
			{
				ErrorMessage += "You must enter a password between 8 and 20 characters.\n";
			}

			if (string.IsNullOrWhiteSpace(Page.FirstNameEntry.Text) || Page.FirstNameEntry.Text.Length < 2 || Page.FirstNameEntry.Text.Length > 20)
			{
				ErrorMessage += "You must enter a first name between 2 and 20 characters.\n";
			}

			if (string.IsNullOrWhiteSpace(Page.LastNameEntry.Text) || Page.LastNameEntry.Text.Length < 2 || Page.LastNameEntry.Text.Length > 20)
			{
				ErrorMessage += "You must enter a last name between 2 and 20 characters.\n";
			}

			if (string.IsNullOrWhiteSpace(Page.UnitEntry.Text))
			{
				ErrorMessage += "You must enter a unit number.\n";
			}

			if (string.IsNullOrWhiteSpace(Page.RentEntry.Text))
			{
				ErrorMessage += "You must enter a rent amount.\n";
			}

			if (Page.PropertyPicker.SelectedItem == null)
			{
				ErrorMessage += "You must select a property.\n";
			}

			if (Page.LeaseMonthsPicker.SelectedItem == null)
			{
				ErrorMessage += "You must select a lease term.\n";
			}

			IsValid = string.IsNullOrWhiteSpace(ErrorMessage);
		}
	}
}
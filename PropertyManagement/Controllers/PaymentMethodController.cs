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
	public class PaymentMethodController : BaseController<PaymentMethodPage>
	{
		public Dictionary<string, int> States { get; set; } = new Dictionary<string, int>
		{
			{ "AL", 1 }, { "AK", 2 }, { "AZ", 3 }, { "AR", 4 }, { "CA", 5 },
			{ "CO", 6 }, { "CT", 7 }, { "DE", 8 }, { "FL", 9 }, { "GA", 10 }, 
			{ "HI", 11 }, { "ID", 12 }, { "IL", 13 }, { "IN", 14 }, { "IA", 15 }, 
			{ "KS", 16 }, { "KY", 17 }, { "LA", 18 }, { "ME", 19 }, { "MD", 20 },
			{ "MA", 21 }, { "MI", 22 }, { "MN", 23 }, { "MS", 24 }, { "MO", 25 },
			{ "MT", 26 }, { "NE", 27 }, { "NV", 28 }, { "NH", 29 }, { "NJ", 30 }, 
			{ "NM", 31 }, { "NY", 32 }, { "NC", 33 }, { "ND", 34 }, { "OH", 35 }, 
			{ "OK", 36 }, { "OR", 37 }, { "PA", 38 }, { "RI", 39 }, { "SC", 40 },
			{ "SD", 41 }, { "TN", 42 }, { "TX", 43 }, { "UT", 44 }, { "VT", 45 }, 
			{ "VA", 46 }, { "WA", 47 }, { "WV", 48 }, { "WI", 49 }, { "WY", 50 }
		};

		private bool IsValid { get; set; }
		private string ErrorMessage { get; set; }

		public PaymentMethodController()
		{
			Page = new PaymentMethodPage(this);
		}

		public void OnSaveButtonTapped(object sender, EventArgs e)
		{
			SetValidationState();

				if (IsValid)
				{
					Task.Run(async () =>
				{
			UserDialogs.Instance.ShowLoading("Saving..", MaskType.Gradient);

			//ApplicationContext.User.CardNumber = Page.CardEntry.Text;
			//ApplicationContext.User.PhoneNumber = Page.PhoneNumberEntry.Text;
			//ApplicationContext.User.Password = Page.PasswordEntry.Text;
			//ApplicationContext.User.FirstName = Page.FirstNameEntry.Text;
			//ApplicationContext.User.LastName = Page.LastNameEntry.Text;
			//ApplicationContext.User.PropertyId = Properties[Page.PropertyPicker.Items[Page.PropertyPicker.SelectedIndex]];
			//ApplicationContext.User.Unit = Page.UnitEntry.Text;
			//ApplicationContext.User.LeaseMonths = LeaseMonths[Page.LeaseMonthsPicker.Items[Page.LeaseMonthsPicker.SelectedIndex]];

			var response = await UserActions.Save();
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

	if (string.IsNullOrWhiteSpace(Page.CardEntry.Text) && string.IsNullOrWhiteSpace(Page.CSCEntry.Text))
	{
		ErrorMessage = "Either the card number or CSC is invalid. Please try again.\n";
	}

	//if (Page.ExpirationPicker.SelectedItem == null)
	//{
	//	ErrorMessage += "You must select an expiration date.\n";
	//}

	if (string.IsNullOrWhiteSpace(Page.NameEntry1.Text) || Page.NameEntry1.Text.Length< 2 || Page.NameEntry1.Text.Length> 20)
	{
		ErrorMessage += "You must enter a first name between 2 and 20 characters.\n";
	}

	if (string.IsNullOrWhiteSpace(Page.NameEntry2.Text) || Page.NameEntry2.Text.Length< 2 || Page.NameEntry2.Text.Length> 20)
	{
		ErrorMessage += "You must enter a last name between 2 and 20 characters.\n";
	}

	if (string.IsNullOrWhiteSpace(Page.ZipEntry.Text) || Page.ZipEntry.Text.Length< 5)
	{
		ErrorMessage += "You must enter a valid zip code.\n";
	}

	if (Page.StatePicker.SelectedItem == null)
	{
		ErrorMessage += "You must select a state. Please try again.\n";
	}

	if (string.IsNullOrWhiteSpace(Page.EmailEntry.Text) && string.IsNullOrWhiteSpace(Page.PhoneEntry.Text))
	{
		ErrorMessage = "Either an email address or phone number must be entered. Please try again.\n";
	}


		IsValid = string.IsNullOrWhiteSpace(ErrorMessage);
		}
	}
}



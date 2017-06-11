using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using PropertyManagement.Models;
using PropertyManagement.Pages;
using Xamarin.Forms;

namespace PropertyManagement.Controllers
{
	public class ServiceController : BaseController<ServicePage>
	{
		public Dictionary<string, ServiceType> Types { get; set; } = new Dictionary<string, ServiceType>
		{
			{ "Plumbing", ServiceType.Plumbing },
			{ "Floors", ServiceType.Floors },
			{ "Electrical", ServiceType.Electrical },
			{ "Windows", ServiceType.Windows },
			{ "Air Conditioning", ServiceType.AirConditioning },
			{ "Lights", ServiceType.Lights },
			{ "Appliances", ServiceType.Appliances },
			{ "Outside", ServiceType.Outside },
			{ "Other", ServiceType.Other }
		};

		public ObservableCollection<ServiceModel> Services { get; private set; } = new ObservableCollection<ServiceModel>
		{
			new ServiceModel
			{
				Id = 1,
				ServiceUserName = null,
				Type = ServiceType.AirConditioning,
				Description = "The air conditioner is not working. It won't come on at all.",
				CreatedTime = DateTime.Now,
				CompletionTime = null,
				CompletionNotes = null
			},
			new ServiceModel
			{
				Id = 2,
				ServiceUserName = "Fred Jones",
				Type = ServiceType.Plumbing,
				Description = "The sink is stopped up completely. Turning it on has caused flooding.",
				CreatedTime = DateTime.Now.AddDays(-2),
				CompletionTime = DateTime.Now,
				CompletionNotes = "The sink was unclogged and water drained."
			}
		};

		private bool IsValid { get; set; }
		private string ErrorMessage { get; set; }

		public ServiceController()
		{
			Page = new ServicePage(this);
		}

		public void OnSubmitButtonTapped(object sender, EventArgs e)
		{
			SetValidationState();

			if (IsValid)
			{
				Task.Run(async () =>
				{
					UserDialogs.Instance.ShowLoading("Submitting..", MaskType.Gradient);

					//ApplicationContext.User.Unit = Page.UnitEntry.Text;
					//ApplicationContext.User.LeaseMonths = LeaseMonths[Page.LeaseMonthsPicker.Items[Page.LeaseMonthsPicker.SelectedIndex]];
					/*
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
					*/
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

			if (string.IsNullOrWhiteSpace(Page.DescriptionEntry.Text))
			{
				ErrorMessage += "You must enter a unit number.\n";
			}

			if (Page.TypePicker.SelectedItem == null)
			{
				ErrorMessage += "You must select a type.\n";
			}

			IsValid = string.IsNullOrWhiteSpace(ErrorMessage);
		}
	}
}
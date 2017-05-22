using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using PropertyManagement.Components;
using PropertyManagement.Pages;
using Xamarin.Forms;

namespace PropertyManagement.Controllers
{
	public class LogInController : BaseController<LogInPage>
	{
		public LogInController() : base()
		{
			Page = new LogInPage(this);
		}

		public void OnExitIconTapped(object sender, EventArgs e) 
		{
			Page.Navigation.PopModalAsync();
		}

		public void OnLogInButtonTapped(object sender, EventArgs e)
		{
			Task.Run(async() =>
			{
				UserDialogs.Instance.ShowLoading("Logging In..", MaskType.Gradient);
				var response = await UserActions.LogIn(Page.EmailOrPhoneEntry.Text, Page.PasswordEntry.Text);
				if (response.Success)
				{
					ApplicationContext.InitializeControllers();
					Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = ApplicationContext.MainController.Page );
				}
				else
				{
					Device.BeginInvokeOnMainThread(() => Page.DisplayAlert(string.Empty, response.ErrorMessage, "OK") );
				}
				UserDialogs.Instance.HideLoading();
			});
		}
	}
}
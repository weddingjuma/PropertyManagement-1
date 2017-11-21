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

        public void OnLogInButtonTapped(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                UserDialogs.Instance.ShowLoading("Logging In..", MaskType.Gradient);
                var response = await UserActions.LogIn(Page.EmailOrPhoneEntry.Text, Page.PasswordEntry.Text);
                if (response.Success)
                {
                    ApplicationContext.InitializeControllers();
                    Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new NavigationPage(ApplicationContext.MainController.Page));
                }
                else
                {
                    //Device.BeginInvokeOnMainThread(() => ApplicationContext.Notification.ShowFailure(response.ErrorMessage, 5));
                }
                UserDialogs.Instance.HideLoading();
            });
        }

        public void OnRegisterButtonTapped(object sender, EventArgs e)
        {
            Page.Navigation.PushModalAsync(new RegisterController().Page);
        }
	}
}
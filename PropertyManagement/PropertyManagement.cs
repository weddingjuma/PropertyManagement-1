using System.Threading.Tasks;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement
{
	public class App : Application
	{
		public App()
		{
            MainPage = new LaunchController().Page;
            OpenInitialPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

        private void OpenInitialPage()
        {
            if (ApplicationContext.IsUserLoggedIn)
            {
                Task.Run(async () =>
                {
                    var response = await UserActions.LogIn();
                    if (response.Success)
                    {
                        ApplicationContext.InitializeControllers();
                        Device.BeginInvokeOnMainThread(() => MainPage = ApplicationContext.MainController.Page);
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() => MainPage = new LogInController().Page);
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => MainPage = new LogInController().Page);
            }
        }
	}
}
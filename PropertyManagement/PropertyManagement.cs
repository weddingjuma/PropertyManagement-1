using System.Threading.Tasks;
using Acr.UserDialogs;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement
{
	public class App : Application
	{
		public App()
		{
			// TODO: add loading screen instead of showing landing every time

			MainPage = new LandingController().Page;

			if (ApplicationContext.IsUserLoggedIn)
			{
				Task.Run(async() =>
				{
					UserDialogs.Instance.ShowLoading("Logging In..", MaskType.Gradient);
					var response = await UserActions.LogIn();
					if (response.Success)
					{
						ApplicationContext.InitializeControllers();
						Device.BeginInvokeOnMainThread(() => MainPage = ApplicationContext.MainController.Page );
					}
					UserDialogs.Instance.HideLoading();
				});
			}
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
	}
}
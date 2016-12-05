using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement
{
	public class App : Application
	{
		public App()
		{
			MainPage = new LandingController().Page;
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
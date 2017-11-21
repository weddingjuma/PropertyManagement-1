using System;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class LandingController : BaseController<LandingPage>
	{
		public LandingController() : base()
		{
			Page = new LandingPage(this);
		}

		public void OnLogInButtonTapped(object sender, EventArgs e)
		{
			Page.Navigation.PushModalAsync(new LogInController().Page);
		}

		public void OnRegisterButtonTapped(object sender, EventArgs e)
		{
			Page.Navigation.PushModalAsync(new RegisterController().Page);
		}
	}
}
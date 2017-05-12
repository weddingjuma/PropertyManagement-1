using System;
using PropertyManagement.Components;
using PropertyManagement.Pages;


namespace PropertyManagement.Controllers
{
	public class RegistrationController : BaseController<RegistrationPage>
	{
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
			App.Current.MainPage = ApplicationContext.MainController.Page;
		}
	}
}
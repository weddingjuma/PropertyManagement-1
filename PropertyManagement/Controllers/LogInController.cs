using System;
using PropertyManagement.Components;
using PropertyManagement.Pages;

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
			App.Current.MainPage = ApplicationContext.MainController.Page;
		}
	}
}
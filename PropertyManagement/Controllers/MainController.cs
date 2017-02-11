using System;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class MainController : BaseController<MainPage>
	{
		public MainController()
		{
			Page = new MainPage(this);
		}
	}
}
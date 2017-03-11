using System;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class SettingsController : BaseController<SettingsPage>
	{
		public SettingsController()
		{
			Page = new SettingsPage(this);
		}
	}
}
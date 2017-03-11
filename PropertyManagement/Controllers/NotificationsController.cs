using System;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class NotificationsController : BaseController<NotificationsPage>
	{
		public NotificationsController()
		{
			Page = new NotificationsPage(this);
		}
	}
}
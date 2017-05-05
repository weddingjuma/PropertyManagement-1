using System;
using System.Collections.ObjectModel;
using PropertyManagement.Models;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class NotificationsController : BaseController<NotificationsPage>
	{
		public ObservableCollection<NotificationModel> Posts { get; private set; } = new ObservableCollection<NotificationModel>
		{
			new NotificationModel
			{
				ProfileImageUrl = "apartment_1.jpg",
				Text = $"Service was completed at your apartment on {DateTime.Now.AddMinutes(-45).ToString()}",
				Date = DateTime.Now.AddSeconds(-45)
			},
			new NotificationModel { ProfileImageUrl = "test_user.jpeg", Text = "Hello. I'm your neighboor Karen. Can you keep it down over there?", Date = DateTime.Now.AddHours(-3) },
			new NotificationModel { ProfileImageUrl = "test_user.jpeg", Text = "Yes, the couch is still for sale; $45", Date = DateTime.Now.AddHours(-16) },
			new NotificationModel { ProfileImageUrl = "apartment_1.jpg", Text = "Your bill is due in 3 days!", Date = DateTime.Now.AddDays(-1) }
		};

		public NotificationsController()
		{
			Page = new NotificationsPage(this);
		}
	}
}
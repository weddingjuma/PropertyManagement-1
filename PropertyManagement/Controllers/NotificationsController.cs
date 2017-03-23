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
				Text = $"Please lock up all pets as pest control will be servicing each apartment on {DateTime.Now.AddDays(15).ToString()}",
				Date = DateTime.Now.AddSeconds(-45)
			},
			new NotificationModel { ProfileImageUrl = "test_user.jpeg", Text = "Hello, this is some post text.", Date = DateTime.Now.AddHours(-3) },
			new NotificationModel { ProfileImageUrl = "test_user.jpeg", Text = "Hello, this is some post text.", Date = DateTime.Now.AddHours(-16) },
			new NotificationModel { ProfileImageUrl = "test_user.jpeg", Text = "Hello, this is some post text.", Date = DateTime.Now.AddDays(-1) },
			new NotificationModel { ProfileImageUrl = "test_user.jpeg", Text = "Hello, this is some post text.", Date = DateTime.Now.AddDays(-3) },
		};

		public NotificationsController()
		{
			Page = new NotificationsPage(this);
		}
	}
}
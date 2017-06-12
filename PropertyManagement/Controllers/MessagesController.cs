using System;
using System.Collections.ObjectModel;
using PropertyManagement.Models;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class MessagesController : BaseController<MessagesPage>
	{
		public ServiceModel Service { get; private set; }

		public ObservableCollection<MessageModel> Messages { get; private set; } = new ObservableCollection<MessageModel>
		{
			new MessageModel
			{
				Id = 1,
				UserId = 1,
				Text = "Hello, has any work been done at my apartment yet?",
				Date = DateTime.Now.AddSeconds(-45)
			},
			new MessageModel
			{
				Id = 2,
				UserId = 2,
				Text = $"Hello, yes, service was completed at your apartment on {DateTime.Now.AddMinutes(-45).ToString()}!",
				Date = DateTime.Now.AddSeconds(-45)
			},
			new MessageModel
			{
				Id = 3,
				UserId = 1,
				Text = "Okay, thank you! I see it working now!",
				Date = DateTime.Now.AddSeconds(-45)
			},
			new MessageModel
			{
				Id = 4,
				UserId = 2,
				Text = "You're welcome!",
				Date = DateTime.Now.AddSeconds(-45)
			}
		};

		public MessagesController(ServiceModel service)
		{
			Service = service;
			Page = new MessagesPage(this);
		}
	}
}
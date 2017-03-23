using System;

namespace PropertyManagement.Models
{
	public class NotificationModel
	{
		public int Id { get; set; }
		public string ProfileImageUrl { get; set; }
		public string IconImageUrl { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }

		public NotificationModel()
		{
		}
	}
}
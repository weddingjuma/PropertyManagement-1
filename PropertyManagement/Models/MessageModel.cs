using System;
using PropertyManagement.Components;

namespace PropertyManagement.Models
{
	public class MessageModel
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }

		public bool IsOutgoing { get { return UserId == ApplicationContext.User.Id; } }

		public MessageModel()
		{
		}
	}
}
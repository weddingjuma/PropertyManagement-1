using System;

namespace PropertyManagement.Models
{
	public class MessageModel
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string ImageUrl { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }

		public MessageModel()
		{
		}
	}
}
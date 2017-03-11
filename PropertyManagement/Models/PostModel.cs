using System;

namespace PropertyManagement.Models
{
	public class PostModel
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }

		public PostModel()
		{
		}
	}
}
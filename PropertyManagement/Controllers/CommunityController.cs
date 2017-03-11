using System;
using System.Collections.ObjectModel;
using PropertyManagement.Models;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class CommunityController : BaseController<CommunityPage>
	{
		public ObservableCollection<PostModel> Posts { get; private set; } = new ObservableCollection<PostModel>
		{
			new PostModel 
			{ 
				ImageUrl = "apartment_1.jpg",
				Name = "Front Office", 
				Text = $"Please lock up all pets as pest control will be servicing each apartment on {DateTime.Now.AddDays(15).ToString()}", 
				Date = DateTime.Now.AddSeconds(-45) 
			},
			new PostModel { ImageUrl = "test_user.jpeg", Name = "@SusanMichell", Text = "Hello, this is some post text.", Date = DateTime.Now.AddHours(-3) },
			new PostModel { ImageUrl = "test_user.jpeg", Name = "@SusanMichell", Text = "Hello, this is some post text.", Date = DateTime.Now.AddHours(-16) },
			new PostModel { ImageUrl = "test_user.jpeg", Name = "@SusanMichell", Text = "Hello, this is some post text.", Date = DateTime.Now.AddDays(-1) },
			new PostModel { ImageUrl = "test_user.jpeg", Name = "@SusanMichell", Text = "Hello, this is some post text.", Date = DateTime.Now.AddDays(-3) },
		};

		public CommunityController()
		{
			Page = new CommunityPage(this);
		}
	}
}
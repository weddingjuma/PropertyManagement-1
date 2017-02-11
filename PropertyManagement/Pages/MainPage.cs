using System;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class MainPage : TabbedPage
	{
		public MainPage(MainController controller)
		{
			Children.Add(ApplicationContext.CommunityController.Page);
		}

		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();

			Title = CurrentPage.Title;
		}
	}
}
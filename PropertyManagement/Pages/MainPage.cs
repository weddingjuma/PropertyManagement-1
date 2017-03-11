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
			Children.Add(ApplicationContext.NotificationsController.Page);
			Children.Add(ApplicationContext.MyHomeController.Page);
			Children.Add(ApplicationContext.SettingsController.Page);
		}

		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();

			Title = CurrentPage.Title;
		}
	}
}
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class MainPage : TabbedPage
	{
		public MainPage(MainController controller)
		{
			AddChild(ApplicationContext.CommunityController.Page);
			AddChild(ApplicationContext.NotificationsController.Page);
			AddChild(ApplicationContext.MyHomeController.Page);
			AddChild(ApplicationContext.SettingsController.Page);
		}

		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();

			Title = CurrentPage.Title;
		}

		private void AddChild(Page page)
		{
			Children.Add(new NavigationPage(page));
		}
	}
}
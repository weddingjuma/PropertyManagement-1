using System;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class NotificationsPage : BasePage<NotificationsController>
	{
		public NotificationsPage(NotificationsController controller) : base(controller)
		{
			Title = "Notifications";
			DefaultIconImage = "notifications_white.png";
			SelectedIconImage = "notifications_white_selected.png";
			BackgroundGradientStartColor = Color.Green;
			BackgroundGradientEndColor = Color.Blue;

			var titleView = new TitleView(Title);

			Content = new StackLayout
			{
				Children = { titleView },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};
		}
	}
}
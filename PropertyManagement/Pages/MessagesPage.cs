using System;
using PropertyManagement.Cells;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class MessagesPage : BasePage<MessagesController>
	{
		public MessagesPage(MessagesController controller) : base(controller)
		{
			Title = !string.IsNullOrWhiteSpace(Controller.Service.ServiceUserName) ? Controller.Service.ServiceUserName : "Messages";
			DefaultIconImage = "settings_white.png";
			SelectedIconImage = "settings_white_selected.png";
			BackgroundGradientStartColor = Color.Green;
			BackgroundGradientEndColor = Color.Blue;

			var titleView = new TitleView(Title, null);

			var listView = new ListView(ListViewCachingStrategy.RecycleElement)
			{
				ItemsSource = Controller.Messages,
				ItemTemplate = new MessageTemplateSelector
				{
					IncomingTemplate = new DataTemplate(typeof(IncomingMessageCell)),
					OutgoingTemplate = new DataTemplate(typeof(OutgoingMessageCell))
				},
				HasUnevenRows = true,
				SeparatorVisibility = SeparatorVisibility.None,
				BackgroundColor = Color.Transparent
			};

			var listViewLayout = new StackLayout
			{
				Children = { listView },
				Padding = new Thickness(25, 10, 25, 0)
			};

			Content = new StackLayout
			{
				Children = { titleView, listViewLayout },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = 0
			};
		}
	}
}
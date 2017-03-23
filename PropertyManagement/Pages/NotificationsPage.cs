using System;
using PropertyManagement.Cells;
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

			var subTitleIconImage = new Image
			{
				Source = ImageSource.FromFile("community_white"),
				Aspect = Aspect.AspectFit,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 25,
				WidthRequest = 25
			};

			var subTitleLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 17,
				TextColor = Color.White,
				Text = "Recent Posts"
			};

			var subTitleLayout = new StackLayout
			{
				Children = { subTitleIconImage, subTitleLabel },
				Orientation = StackOrientation.Horizontal,
				Spacing = 10,
				Padding = new Thickness(0, 0, 0, 10)
			};

			var headerLayout = new StackLayout
			{
				Children = { subTitleLayout },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0
			};

			var listView = new ListView(ListViewCachingStrategy.RecycleElement)
			{
				ItemsSource = Controller.Posts,
				ItemTemplate = new DataTemplate(typeof(NotificationCell)),
				HasUnevenRows = true,
				SeparatorVisibility = SeparatorVisibility.None,
				BackgroundColor = Color.Transparent,
				Header = headerLayout
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
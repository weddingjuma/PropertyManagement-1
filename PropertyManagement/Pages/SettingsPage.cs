using System;
using PropertyManagement.Components;
using PropertyManagement.Controllers;
using PropertyManagement.Renderers;
using PropertyManagement.Views;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class SettingsPage : BasePage<SettingsController>
	{
		public SettingsPage(SettingsController controller) : base(controller)
		{
			Title = "Settings";
			DefaultIconImage = "settings_white.png";
			SelectedIconImage = "settings_white_selected.png";
			BackgroundGradientStartColor = Color.FromHex("42275a");
			BackgroundGradientEndColor = Color.FromHex("42275a");

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
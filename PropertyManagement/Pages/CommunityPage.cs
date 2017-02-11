using System;
using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
	public class CommunityPage : BasePage<CommunityController>
	{
		public CommunityPage(CommunityController controller) : base(controller)
		{
			Title = "Community";
			Icon = (Xamarin.Forms.FileImageSource)ImageSource.FromFile("logo_white.png");
		}
	}
}
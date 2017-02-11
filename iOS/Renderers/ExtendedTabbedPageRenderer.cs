using Foamlife.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace Foamlife.iOS.Renderers
{
	public class ExtendedTabbedPageRenderer : TabbedRenderer
	{
		private const string FONT_NAME = "AvenirNext-Bold";

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			var navigationBarTextAttributes = new UITextAttributes();
			navigationBarTextAttributes.Font = UIFont.FromName(FONT_NAME, 14.0F);
			navigationBarTextAttributes.TextColor = UIColor.FromRGB(0.40F, 0.40F, 0.40F);
			UINavigationBar.Appearance.SetTitleTextAttributes(navigationBarTextAttributes);

			var tabBarTextAttributes = new UITextAttributes();
			tabBarTextAttributes.Font = UIFont.FromName(FONT_NAME, 9.0F);
			UITabBarItem.Appearance.SetTitleTextAttributes(tabBarTextAttributes, UIControlState.Normal);
		}
	}
}
using Foamlife.iOS.Renderers;
using PropertyManagement.Components;
using PropertyManagement.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace Foamlife.iOS.Renderers
{
	public class ExtendedTabbedPageRenderer : TabbedRenderer
	{
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			var tabbedPage = Element as TabbedPage;
			for (int i = 0; i < TabBar.Items.Length; i++)
			{
				UpdateTabBarItem(TabBar.Items[i], (tabbedPage.Children[i] as ExtendedPage));
			}
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			var navigationBarTextAttributes = new UITextAttributes();
			navigationBarTextAttributes.Font = UIFont.FromName(ApplicationSettings.RegularFontFamily, 14.0F);
			navigationBarTextAttributes.TextColor = UIColor.FromRGB(0.40F, 0.40F, 0.40F);
			UINavigationBar.Appearance.SetTitleTextAttributes(navigationBarTextAttributes);

			TabBar.BackgroundColor = UIColor.Black.ColorWithAlpha(0.20F);
			TabBar.BackgroundImage = new UIImage();

			TabBar.Layer.BorderWidth = 0.50F;
			TabBar.Layer.BorderColor = UIColor.Clear.CGColor;
			TabBar.ClipsToBounds = true;
		}

		private void UpdateTabBarItem(UITabBarItem item, ExtendedPage page)
		{
			item.Image = UIImage.FromBundle(page.DefaultIconImage);
			item.Image = item.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

			item.SelectedImage = UIImage.FromBundle(page.SelectedIconImage);
			item.SelectedImage = item.SelectedImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

			item.SelectedImage.AccessibilityIdentifier = page.DefaultIconImage;

			item.ImageInsets = new UIEdgeInsets(6, 0, -6, 0);
			item.Title = "";
		}
	}
}
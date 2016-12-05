using CoreAnimation;
using CoreGraphics;
using PropertyManagement.iOS.Renderers;
using PropertyManagement.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedPage), typeof(ExtendedPageRenderer))]
namespace PropertyManagement.iOS.Renderers
{
	public class ExtendedPageRenderer : PageRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var page = e.NewElement as ExtendedPage;

				int layerIndex = 0;

				if (page.IsBackgroundImageSet)
				{
					var backgroundImagelayer = new CALayer();
					backgroundImagelayer.Frame = View.Bounds;
					backgroundImagelayer.Contents = new UIImage(page.BackgroundImage).CGImage;
					backgroundImagelayer.ContentsGravity = CALayer.GravityResizeAspectFill;
					View.Layer.InsertSublayer(backgroundImagelayer, layerIndex);
					layerIndex++;
				}

				if (page.IsBackgroundGradientSet)
				{
					var gradientLayer = new CAGradientLayer();
					gradientLayer.Frame = View.Bounds;
					gradientLayer.Colors = new CGColor[] { page.BackgroundGradientStartColor.Value.ToCGColor(), page.BackgroundGradientEndColor.Value.ToCGColor() };
					gradientLayer.StartPoint = new CGPoint(0, 0);
					gradientLayer.EndPoint = new CGPoint(1, 1);
					gradientLayer.Opacity = (float)0.9;
					View.Layer.InsertSublayer(gradientLayer, layerIndex);
					layerIndex++;
				}
			}
		}
	}
}
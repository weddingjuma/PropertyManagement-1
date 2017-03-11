using CoreGraphics;
using PropertyManagement.iOS.Renderers;
using PropertyManagement.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(ExtendedFrameRenderer))]
namespace PropertyManagement.iOS.Renderers
{
	public class ExtendedFrameRenderer : FrameRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var frame = e.NewElement as ExtendedFrame;

				Layer.BackgroundColor = frame.ActualBackgroundColor.ToCGColor();

				Layer.CornerRadius = (float)frame.CornerRadius;
				//Layer.Bounds.Inset(1, 1);
				Layer.BorderColor = frame.BorderColor.ToCGColor();
				Layer.BorderWidth = (float)frame.BorderWidth;

				Layer.ShadowColor = frame.ShadowColor.ToCGColor();
				Layer.ShadowOpacity = (float)frame.ShadowOpacity;
				Layer.ShadowRadius = (float)frame.ShadowBlurRadius;
				Layer.ShadowOffset = new CGSize(frame.ShadowOffsetX, frame.ShadowOffsetY);
				Layer.MasksToBounds = true;
			}
		}
	}
}
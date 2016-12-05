using System;
using CoreGraphics;
using PropertyManagement.iOS.Renderers;
using PropertyManagement.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]
namespace PropertyManagement.iOS.Renderers
{
	public class ExtendedLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var label = e.NewElement as ExtendedLabel;

				Control.Layer.ShadowColor = label.ShadowColor.ToCGColor();
				Control.Layer.ShadowRadius = (float)label.ShadowBlurRadius;
				Control.Layer.ShadowOffset = new CGSize(label.ShadowOffsetX, label.ShadowOffsetY);
				Control.Layer.ShadowOpacity = (float)label.ShadowOpacity;
			}
		}
	}
}
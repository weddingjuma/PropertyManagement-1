using CoreGraphics;
using PropertyManagement.iOS.Renderers;
using PropertyManagement.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace PropertyManagement.iOS.Renderers
{
	public class ExtendedEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged(e);

			if (this.Control != null && e.OldElement == null)
			{
				var entry = e.NewElement as ExtendedEntry;

				if (entry.BorderWidth == 0)
				{
					Control.BorderStyle = UITextBorderStyle.None;
				}
			}
		}
	}
}
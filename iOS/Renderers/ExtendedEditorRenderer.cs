using CoreGraphics;
using PropertyManagement.iOS.Renderers;
using PropertyManagement.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEditor), typeof(ExtendedEditorRenderer))]
namespace PropertyManagement.iOS.Renderers
{
	public class ExtendedEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (this.Control != null && e.OldElement == null)
			{
				var entry = e.NewElement as ExtendedEditor;
			}
		}
	}
}

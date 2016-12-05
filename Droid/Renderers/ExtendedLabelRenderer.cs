using PropertyManagement.Droid.Renderers;
using PropertyManagement.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]
namespace PropertyManagement.Droid.Renderers
{
	public class ExtendedLabelRenderer : LabelRenderer
	{
		public ExtendedLabelRenderer()
		{
		}
	}
}
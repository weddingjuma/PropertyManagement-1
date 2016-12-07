using PropertyManagement.Droid.Renderers;
using PropertyManagement.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(ExtendedFrameRenderer))]
namespace PropertyManagement.Droid.Renderers
{
	public class ExtendedFrameRenderer : FrameRenderer
	{
		public ExtendedFrameRenderer()
		{
		}
	}
}
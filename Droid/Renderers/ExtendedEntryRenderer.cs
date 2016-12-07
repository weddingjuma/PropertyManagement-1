using PropertyManagement.Droid.Renderers;
using PropertyManagement.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace PropertyManagement.Droid.Renderers
{
	public class ExtendedEntryRenderer : EntryRenderer
	{
		public ExtendedEntryRenderer()
		{
		}
	}
}
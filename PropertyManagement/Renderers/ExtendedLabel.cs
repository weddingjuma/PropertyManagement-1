using Xamarin.Forms;

namespace PropertyManagement.Renderers
{
	public class ExtendedLabel : Label
	{
		public Color ShadowColor { get; set; }
		public double ShadowBlurRadius { get; set; }
		public double ShadowOffsetX { get; set; }
		public double ShadowOffsetY { get; set; }
		public double ShadowOpacity { get; set; }

		public ExtendedLabel()
		{
			ShadowColor = Color.Black;
			ShadowOpacity = 1.0;
		}
	}
}
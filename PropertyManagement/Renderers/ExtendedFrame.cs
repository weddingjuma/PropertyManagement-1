using Xamarin.Forms;

namespace PropertyManagement.Renderers
{
	public class ExtendedFrame : Frame
	{
		public Color ActualBackgroundColor { get; set; }
		public double CornerRadius { get; set; }
		public Color BorderColor { get; set; }
        public double BorderWidth { get; set; }
		public Color ShadowColor { get; set; }
        public double ShadowOpacity { get; set; }
        public double ShadowBlurRadius { get; set; }
        public double ShadowOffsetX { get; set; }
		public double ShadowOffsetY { get; set; }

		public ExtendedFrame()
		{
			ShadowColor = Color.Black;
			ShadowOpacity = 0;
		}
	}
}
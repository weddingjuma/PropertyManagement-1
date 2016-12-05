using Xamarin.Forms;

namespace PropertyManagement.Renderers
{
	public class ExtendedPage : ContentPage
	{
		public Color? BackgroundGradientStartColor { get; set; }
		public Color? BackgroundGradientEndColor { get; set; }
		public bool IsBackgroundGradientSet
		{
			get
			{
				return BackgroundGradientStartColor != null && BackgroundGradientEndColor != null;
			}
		}

		public bool IsBackgroundImageSet
		{
			get
			{
				return !string.IsNullOrWhiteSpace(BackgroundImage);
			}
		}

		public ExtendedPage()
		{
		}
	}
}
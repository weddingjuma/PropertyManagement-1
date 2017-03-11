using Xamarin.Forms;

namespace PropertyManagement.Renderers
{
	public class ExtendedPage : ContentPage
	{
		public string DefaultIconImage { get; set; }
		public string SelectedIconImage { get; set; }
		public Color? BackgroundGradientStartColor { get; set; }
		public Color? BackgroundGradientEndColor { get; set; }

		public bool IsDefaultIconImageSet
		{
			get
			{
				return !string.IsNullOrWhiteSpace(DefaultIconImage); 
			}
		}

		public bool IsSelectedIconImageSet
		{
			get
			{
				return !string.IsNullOrWhiteSpace(SelectedIconImage);
			}
		}

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
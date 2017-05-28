using System;
using Xamarin.Forms;

namespace PropertyManagement.Renderers
{
	public class ExtendedPicker : Picker
	{
		public double FontSize { get; set; }
		public Color BorderColor { get; set; }

		public ExtendedPicker()
		{
			FontSize = 15;
			BorderColor = Color.FromHex("f5f5f5");
		}
	}
}
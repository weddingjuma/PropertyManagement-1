using System;
using Xamarin.Forms;

namespace PropertyManagement.Renderers
{
	public class ExtendedDatePicker : DatePicker
	{
		public double FontSize { get; set; }
		public Color BorderColor { get; set; }

		public ExtendedDatePicker()
		{
			FontSize = 15;
			BorderColor = Color.FromHex("f5f5f5");
		}
	}
}
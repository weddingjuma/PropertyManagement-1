using System;
using PropertyManagement.Components;
using PropertyManagement.iOS.Renderers;
using PropertyManagement.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedDatePicker), typeof(ExtendedDatePickerRenderer))]
namespace PropertyManagement.iOS.Renderers
{
	public class ExtendedDatePickerRenderer : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var picker = e.NewElement as ExtendedDatePicker;

				Control.Font = UIFont.FromName(ApplicationSettings.RegularFontFamily, (nfloat)picker.FontSize);
				Control.Layer.BorderColor = picker.BorderColor.ToCGColor();
			}
		}
	}
}
using System;
using PropertyManagement.Components;
using PropertyManagement.iOS.Renderers;
using PropertyManagement.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedPicker), typeof(ExtendedPickerRenderer))]
namespace PropertyManagement.iOS.Renderers
{
	public class ExtendedPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var picker = e.NewElement as ExtendedPicker;

				Control.Font = UIFont.FromName(ApplicationSettings.RegularFontFamily, (nfloat)picker.FontSize);
				Control.Layer.BorderColor = picker.BorderColor.ToCGColor();
			}
		}
	}
}
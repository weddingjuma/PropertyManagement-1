using Android.Graphics;
using PropertyManagement.Droid.Renderers;
using PropertyManagement.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedPage), typeof(ExtendedPageRenderer))]
namespace PropertyManagement.Droid.Renderers
{
	public class ExtendedPageRenderer : PageRenderer
	{
		private Xamarin.Forms.Color? BackgroundGradientStartColor { get; set; }
		private Xamarin.Forms.Color? BackgroundGradientEndColor { get; set; }
		private bool IsBackgroundGradientSet { get; set; }

		protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
		{
			if (IsBackgroundGradientSet)
			{
				var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,
					BackgroundGradientStartColor.Value.ToAndroid(),
					BackgroundGradientEndColor.Value.ToAndroid(),
					Shader.TileMode.Mirror);
				var paint = new Paint() { Dither = true };
				paint.SetShader(gradient);
				canvas.DrawPaint(paint);
				base.DispatchDraw(canvas);
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
			{
				return;
			}

			var page = e.NewElement as ExtendedPage;

			if (page.IsBackgroundGradientSet)
			{
				BackgroundGradientStartColor = page.BackgroundGradientStartColor;
				BackgroundGradientEndColor = page.BackgroundGradientEndColor;
				IsBackgroundGradientSet = true;
			}
		}
	}
}
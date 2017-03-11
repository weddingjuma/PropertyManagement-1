using System;
using PropertyManagement.Components;
using PropertyManagement.Models;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public class PostCell : ViewCell
	{
		public static int FixedHeight = 120;

		private Image ProfileImage { get; set; }
		private Label DateLabel { get; set; }
		private Label NameLabel { get; set; }
		private Label TextLabel { get; set; }

		public PostCell()
		{
			ProfileImage = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 40,
				WidthRequest = 40
			};

			var profileImageFrame = new ExtendedFrame
			{
				Content = ProfileImage,
				Padding = 0,
				HasShadow = false,
				CornerRadius = 20,
				BorderWidth = 0,
				HeightRequest = 40,
				WidthRequest = 40,
				ShadowColor = Color.Transparent,
				ShadowOpacity = 0,
				ShadowBlurRadius = 0,
				ShadowOffsetX = 0,
				ShadowOffsetY = 0,
			};

			NameLabel = new Label
			{
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("7f8c8d")
			};

			DateLabel = new Label
			{
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 13,
				TextColor = Color.FromHex("7f8c8d")
			};

			var DetailsLayout = new StackLayout
			{
				Children = { NameLabel, DateLabel }
			};

			var headerLayout = new StackLayout
			{
				Children = { profileImageFrame, DetailsLayout },
				Orientation = StackOrientation.Horizontal,
				Spacing = 10
			};

			TextLabel = new Label
			{
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("282830")
			};

			var textLayout = new StackLayout
			{
				Children = { TextLabel },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = 0
			};

			var frame = new ExtendedFrame
			{
				Content = new StackLayout
				{
					Children = { headerLayout, textLayout },
					Spacing = 10
				},
				OutlineColor = Color.White,
				ActualBackgroundColor = Color.White,
				HasShadow = false,
				CornerRadius = 3,
				BorderWidth = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = 20
			};

			View = new StackLayout
			{
				Children = { frame, new BoxView { HeightRequest = 0, WidthRequest = 0 } },
				Spacing = 10
			};
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var item = BindingContext as PostModel;
			if (item != null)
			{
				//ProfileImage.Source = $"http://www.wavelinkllc.com/foamlife{item.ImageUrl1}";
				ProfileImage.Source = ImageSource.FromFile(item.ImageUrl);
				NameLabel.Text = item.Name;
				TextLabel.Text = item.Text;
				DateLabel.Text = Formatter.TimeSince(item.Date);
			}
		}
	}
}
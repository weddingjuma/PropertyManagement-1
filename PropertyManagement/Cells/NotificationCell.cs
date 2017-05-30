using System;
using PropertyManagement.Components;
using PropertyManagement.Models;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public class NotificationCell : ViewCell
	{
		private Image ProfileImage { get; set; }
		private Image IconImage { get; set; }
		private Label TextLabel { get; set; }
		private Label DateLabel { get; set; }

		public NotificationCell()
		{
			ProfileImage = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 50,
				WidthRequest = 50
			};

			var profileImageFrame = new ExtendedFrame
			{
				Content = ProfileImage,
				Padding = 0,
				HasShadow = false,
				CornerRadius = 25,
				BorderWidth = 0,
				HeightRequest = 50,
				WidthRequest = 50,
				MinimumWidthRequest = 50,
				MinimumHeightRequest = 50,
				ShadowColor = Color.Transparent,
				ShadowOpacity = 0,
				ShadowBlurRadius = 0,
				ShadowOffsetX = 0,
				ShadowOffsetY = 0,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start
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

			DateLabel = new Label
			{
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 13,
				TextColor = Color.FromHex("7f8c8d")
			};

			var DetailsLayout = new StackLayout
			{
				Children = { textLayout, DateLabel }
			};

			var frame = new ExtendedFrame
			{
				Content = new StackLayout
				{
					Children = { DetailsLayout }
				},
				OutlineColor = Color.White,
				ActualBackgroundColor = Color.White,
				HasShadow = false,
				CornerRadius = 3,
				BorderWidth = 0,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = 20
			};

			var postLayout = new StackLayout
			{
				Children = { profileImageFrame, frame },
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10
			};

			View = new StackLayout
			{
				Children = { postLayout, new BoxView { HeightRequest = 0, WidthRequest = 0 } },
				Spacing = 10,
				Padding = new Thickness(0, 1)
			};
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var item = BindingContext as NotificationModel;
			if (item != null)
			{
				//ProfileImage.Source = $"http://www.wavelinkllc.com/foamlife{item.ImageUrl1}";
				ProfileImage.Source = ImageSource.FromFile(item.ProfileImageUrl);
				TextLabel.Text = item.Text;
				DateLabel.Text = Formatter.TimeSince(item.Date);
			}
		}
	}
}
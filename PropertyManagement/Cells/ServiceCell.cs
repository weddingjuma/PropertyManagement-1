using System;
using PropertyManagement.Components;
using PropertyManagement.Models;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public class ServiceCell : ViewCell
	{
		private Image StatusImage { get; set; }
		private Label DateLabel { get; set; }
		private Label StatusLabel { get; set; }
		private Label TextLabel { get; set; }

		public ServiceCell()
		{
			StatusImage = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 40,
				WidthRequest = 40
			};

			var profileImageFrame = new ExtendedFrame
			{
				Content = StatusImage,
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

			StatusLabel = new Label
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
				Children = { StatusLabel, DateLabel }
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
				Spacing = 10,
				Padding = new Thickness(0, 1)
			};
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var item = BindingContext as ServiceModel;
			if (item != null)
			{
				StatusImage.Source = ImageSource.FromFile(item.IsCompleted ? "checkmark_black.png" : "ellipsis_black.png");
				StatusLabel.Text = item.IsAssigned ? item.IsCompleted ? $"Completed by {item.ServiceUserName}" : $"Accepted by {item.ServiceUserName}" : "Pending response";
				TextLabel.Text = !string.IsNullOrWhiteSpace(item.CompletionNotes) ? $"{item.ServiceUserName}: {item.CompletionNotes}" : item.Description;
				DateLabel.Text = Formatter.TimeSince(item.CompletionTime != null ? item.CompletionTime.Value : item.CreatedTime);
			}
		}
	}
}
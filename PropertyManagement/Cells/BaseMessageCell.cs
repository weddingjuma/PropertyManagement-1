using System;
using PropertyManagement.Components;
using PropertyManagement.Models;
using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public abstract class BaseMessageCell : ViewCell
	{
		private Label DateLabel { get; set; }
		private Label TextLabel { get; set; }

		public BaseMessageCell()
		{
			DateLabel = new Label
			{
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 13,
				TextColor = Color.White
			};

			TextLabel = new Label
			{
				BackgroundColor = Color.Transparent,
				FontFamily = ApplicationSettings.RegularFontFamily,
				FontSize = 15,
				TextColor = Color.FromHex("282830")
			};

			var frame = new ExtendedFrame
			{
				Content = TextLabel,
				OutlineColor = Color.White,
				ActualBackgroundColor = Color.White,
				HasShadow = false,
				CornerRadius = 5,
				BorderWidth = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = 15
			};

			var messageGrid = GetMessageGrid(frame, TextLabel, DateLabel);

			View = new StackLayout
			{
				Children = { messageGrid, new BoxView { HeightRequest = 0, WidthRequest = 0 } },
				Spacing = 10,
				Padding = new Thickness(0, 1)
			};
		}

		protected abstract Grid GetMessageGrid(ExtendedFrame frame, Label textLabel, Label dateLabel); 

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var item = BindingContext as MessageModel;
			if (item != null)
			{
				TextLabel.Text = item.Text;
				DateLabel.Text = Formatter.TimeSince(item.Date);
			}
		}
	}
}
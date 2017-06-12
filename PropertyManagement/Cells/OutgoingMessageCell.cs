using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public class OutgoingMessageCell : BaseMessageCell
	{
		public OutgoingMessageCell()
		{
		}

		protected override Grid GetMessageGrid(ExtendedFrame frame, Label textLabel, Label dateLabel)
		{
			frame.ActualBackgroundColor = Color.Transparent;
			frame.BorderWidth = 1;
			frame.BorderColor = Color.White;
			frame.HorizontalOptions = LayoutOptions.End;
			textLabel.TextColor = Color.White;
			dateLabel.HorizontalOptions = LayoutOptions.End;
			var grid = new Grid();
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			grid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength(3, GridUnitType.Star) });
			grid.Children.Add(frame, 1, 0);
			grid.Children.Add(dateLabel, 1, 1);
			return grid;
		}
	}
}
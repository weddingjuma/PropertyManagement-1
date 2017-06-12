using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public class IncomingMessageCell : BaseMessageCell
	{
		public IncomingMessageCell()
		{
		}

		protected override Grid GetMessageGrid(ExtendedFrame frame, Label textLabel, Label dateLabel)
		{
			frame.HorizontalOptions = LayoutOptions.Start;
			dateLabel.HorizontalOptions = LayoutOptions.Start;
			var grid = new Grid();
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			grid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength(3, GridUnitType.Star) });
			grid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) });
			grid.Children.Add(frame, 0, 0);
			grid.Children.Add(dateLabel, 0, 1);
			return grid;
		}
	}
}
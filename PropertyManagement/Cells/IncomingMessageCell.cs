using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public class IncomingMessageCell : BaseMessageCell
	{
		public IncomingMessageCell()
		{
		}

		protected override StackLayout GetMessageLayout(ExtendedFrame profileImageFrame, ExtendedFrame messageframe)
		{
			return new StackLayout
			{
				Children = { profileImageFrame, messageframe },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = 0
			};
		}
	}
}
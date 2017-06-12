using PropertyManagement.Renderers;
using Xamarin.Forms;

namespace PropertyManagement.Cells
{
	public class OutgoingMessageCell : BaseMessageCell
	{
		public OutgoingMessageCell()
		{
		}

		protected override StackLayout GetMessageLayout(ExtendedFrame profileImageFrame, ExtendedFrame messageframe)
		{
			return new StackLayout
			{
				Children = { messageframe, profileImageFrame },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = 0
			};
		}
	}
}
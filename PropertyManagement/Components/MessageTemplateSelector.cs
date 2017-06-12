using System;
using PropertyManagement.Models;
using Xamarin.Forms;

namespace PropertyManagement.Components
{
	public class MessageTemplateSelector : DataTemplateSelector
	{
		public DataTemplate IncomingTemplate { get; set; }
		public DataTemplate OutgoingTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return ((MessageModel)item).IsOutgoing ? OutgoingTemplate : IncomingTemplate;
		}
	}
}
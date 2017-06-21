using System;

namespace PropertyManagement.Models
{
	public class PaymentHistoryModel
	{
		public int Id { get; set; }
		public string Date { get; set; }
		public string Method { get; set; }
		public string Amount { get; set; }
		public string PaymentType { get; set; }
		public string DisplayText { get; set; }


		public PaymentHistoryModel()
		{
		}
	}

	//public enum PaymentHistory
	//{
	//	Date = 0,
	//	Method = 1,
	//	Amount = 2
	//}

}
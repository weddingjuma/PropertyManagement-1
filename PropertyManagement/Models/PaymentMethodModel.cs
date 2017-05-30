using System;

namespace PropertyManagement.Models
{
	public class PaymentMethodModel
	{
		public int Id { get; set; }
		public string PaymentId { get; set; }
		public PaymentMethodService Service { get; set; }
		public PaymentMethodType Type { get; set; }
		public string DisplayText { get; set; }

		public PaymentMethodModel()
		{
		}
	}

	public enum PaymentMethodService
	{
		PayPal = 0,
		AuthorizeDotNet = 1,
		Stripe = 2
	}

	public enum PaymentMethodType
	{
		Bank = 0,
		Card = 1,
		Account = 2
	}
}
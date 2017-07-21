using System;
using System.Collections.ObjectModel;
using PropertyManagement.Models;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class RentPaymentController : BaseController<RentPaymentPage>
	{
		public ObservableCollection<PaymentMethodModel> PaymentMethods { get; private set; } = new ObservableCollection<PaymentMethodModel>
		{
			new PaymentMethodModel
			{
				Id = 1,
				PaymentId = "10",
				Service = PaymentMethodService.AuthorizeDotNet,
				Type = PaymentMethodType.Card,
				DisplayText = "************4326"
			},
			new PaymentMethodModel
			{
				Id = 2,
				PaymentId = "susan@gmail.com",
				Service = PaymentMethodService.PayPal,
				Type = PaymentMethodType.Account,
				DisplayText = "susan@gmail.com"
			},
			new PaymentMethodModel
			{
				Id = 3,
				PaymentId = "30",
				Service = PaymentMethodService.Stripe,
				Type = PaymentMethodType.Bank,
				DisplayText = "************7898"
			}
		};

		public RentPaymentController()
		{
			Page = new RentPaymentPage(this);
		}

		public void OnMethodButtonTapped(object sender, EventArgs e)
		{
			Page.Navigation.PushAsync(new PaymentMethodController().Page);
		}
	}
}
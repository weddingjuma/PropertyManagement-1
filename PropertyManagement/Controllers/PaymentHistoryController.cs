using System;
using System.Collections.ObjectModel;
using PropertyManagement.Models;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class PaymentHistoryController : BaseController<PaymentHistoryPage>
	{
		public PaymentHistoryController()
		{
			Page = new PaymentHistoryPage(this);
		}
	}
}

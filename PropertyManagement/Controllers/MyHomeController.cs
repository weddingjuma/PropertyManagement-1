using System;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class MyHomeController : BaseController<MyHomePage>
	{
		public MyHomeController()
		{
			Page = new MyHomePage(this);
		}

		public void OnPaymentButtonTapped(object sender, EventArgs e)
		{
			Page.Navigation.PushAsync(new RentPaymentController().Page);
		}

		public void OnHistoryButtonTapped(object sender, EventArgs e)
		{
			Page.Navigation.PushAsync(new PaymentHistoryController().Page);
		}

		public void OnContactButtonTapped(object sender, EventArgs e)
		{
			Page.Navigation.PushAsync(new ContactOfficeController().Page);
		}

		public void OnSettingsButtonTapped(object sender, EventArgs e)
		{
			Page.Navigation.PushAsync(new SettingsController().Page);
		}
	}
}
using Xamarin.Forms;

namespace PropertyManagement.Controllers
{
	public class BaseController<T>
	{
		public T Page { get; set; }

		public BaseController()
		{
			
		}

		public void BackButtonTapped()
		{
			(Page as Page).Navigation.PopAsync();
		}
	}
}
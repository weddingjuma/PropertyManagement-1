using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class LandingController : BaseController<LandingPage>
	{
		public LandingController() : base()
		{
			Page = new LandingPage(this);
		}
	}
}
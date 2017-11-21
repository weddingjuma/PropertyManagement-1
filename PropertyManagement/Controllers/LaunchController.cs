using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
    public class LaunchController : BaseController<LaunchPage>
    {
        public LaunchController() : base()
        {
            Page = new LaunchPage(this);
        }
    }
}
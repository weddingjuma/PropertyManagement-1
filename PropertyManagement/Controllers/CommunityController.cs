using System;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
	public class CommunityController : BaseController<CommunityPage>
	{
		public CommunityController()
		{
			Page = new CommunityPage(this);
		}
	}
}

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
	}
}
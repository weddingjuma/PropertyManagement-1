using System;
using System.Collections.ObjectModel;
using PropertyManagement.Models;
using PropertyManagement.Pages;

namespace PropertyManagement.Controllers
{
public class ContactOfficeController : BaseController<ContactOfficePage>
	{
		public ContactOfficeController()
		{
			Page = new ContactOfficePage(this);
		}
	}
}


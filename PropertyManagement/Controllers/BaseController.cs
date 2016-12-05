namespace PropertyManagement.Controllers
{
	public class BaseController<T>
	{
		public T Page { get; set; }

		public BaseController()
		{
			
		}
	}
}
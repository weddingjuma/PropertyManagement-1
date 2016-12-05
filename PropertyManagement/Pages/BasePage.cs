using PropertyManagement.Renderers;

namespace PropertyManagement.Pages
{
	public class BasePage<T> : ExtendedPage
	{
		public T Controller { get; private set; }

		public BasePage(T controller)
		{
			Controller = controller;
		}
	}
}
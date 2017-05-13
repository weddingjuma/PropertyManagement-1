using PropertyManagement.Controllers;
using PropertyManagement.Models;
using Xamarin.Forms;

namespace PropertyManagement.Components
{
	public static class ApplicationContext
	{
		public static UserModel User = new UserModel();
		public static bool IsUserLoggedIn { get { return Application.Current.Properties.ContainsKey("User.EmailOrPhone") && !string.IsNullOrWhiteSpace((string)Application.Current.Properties["User.EmailOrPhone"]); } }
		public static bool IsUserLoaded { get { return User != null && User.Id != 0; } }
		public static bool IsDataRefreshNeeded { get; set; } = false;

		//public static IDevice Device { get; } = DependencyService.Get<IDevice>();
		//public static ILinker Linker { get; } = DependencyService.Get<ILinker>();
		//public static ISharer Sharer { get; } = DependencyService.Get<ISharer>();

		public static CommunityController CommunityController { get; } = new CommunityController();
		public static NotificationsController NotificationsController { get; } = new NotificationsController();
		public static MyHomeController MyHomeController { get; } = new MyHomeController();
		public static SettingsController SettingsController { get; } = new SettingsController();
		public static MainController MainController { get; } = new MainController();
	}
}
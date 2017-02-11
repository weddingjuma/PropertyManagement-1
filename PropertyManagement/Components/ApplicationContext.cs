﻿using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement.Components
{
	public static class ApplicationContext
	{
		//public static IDevice Device { get; } = DependencyService.Get<IDevice>();
		//public static ILinker Linker { get; } = DependencyService.Get<ILinker>();
		//public static ISharer Sharer { get; } = DependencyService.Get<ISharer>();

		public static CommunityController CommunityController { get; } = new CommunityController();
		public static MainController MainController { get; } = new MainController();
	}
}
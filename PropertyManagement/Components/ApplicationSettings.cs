using Xamarin.Forms;

namespace PropertyManagement.Components
{
	public static class ApplicationSettings
	{
        public const string AppId = "123";
		public const string AppName = "PropertyManagement";
		public const string Version = "1.0";

		public const string Email = "development@wavelinkllc.com";
		public const string TwitterHandle = "WaveLinkLLC";
		public const string InstagramHandle = "WaveLinkLLC";
		public const string FacebookId = "123";
		public const string FacebookName = "WaveLinkLLC";
		public const string SnapchatName = "WaveLinkLLC";

        public static string RegularFontFamily { get { return Device.OnPlatform(iOS: "PingFangTC-Regular", Android: "Droid Sans Mono", WinPhone: null); } }
        public static string ThinFontFamily { get { return Device.OnPlatform(iOS: "PingFangTC-Thin", Android: "Droid Sans Mono", WinPhone: null); } }
        public static string BoldFontFamily { get { return Device.OnPlatform(iOS: "PingFangTC-Semibold", Android: "Droid Sans Mono", WinPhone: null); } }
	}
}
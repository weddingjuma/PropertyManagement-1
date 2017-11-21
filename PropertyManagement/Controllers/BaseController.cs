using System.Threading.Tasks;
using Acr.UserDialogs;
using PropertyManagement.Components;
using Xamarin.Forms;

namespace PropertyManagement.Controllers
{
	public class BaseController<T>
	{
        public T Page { get; set; }
        public bool IsInitialized { get; set; } = false;

        public void OnBackButtonTapped()
        {
            (Page as Page).Navigation.PopAsync();
        }

        public void OnSettingsButtonTapped()
        {
            (Page as Page).Navigation.PushAsync(new SettingsController().Page);
        }

        protected async Task LogOut()
        {
            UserDialogs.Instance.ShowLoading("Logging Out..", MaskType.Gradient);
            await UserActions.LogOut();
            UserDialogs.Instance.HideLoading();
            Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new LogInController().Page);
        }
	}
}
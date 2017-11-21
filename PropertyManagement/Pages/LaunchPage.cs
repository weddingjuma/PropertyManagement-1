using PropertyManagement.Controllers;
using Xamarin.Forms;

namespace PropertyManagement.Pages
{
    public class LaunchPage : BasePage<LaunchController>
    {
        public LaunchPage(LaunchController controller) : base(controller)
        {
            Title = "LAUNCH";
            BackgroundColor = Color.GhostWhite;

            var logoIcon = new Image
            {
                Source = ImageSource.FromFile("logo"),
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 35
            };

            var activityIndicator = new ActivityIndicator
            {
                Color = Color.Gray,
                IsRunning = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Content = new StackLayout
            {
                Children = { logoIcon, activityIndicator },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10
            };
        }
    }
}
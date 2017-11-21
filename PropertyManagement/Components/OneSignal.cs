using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PropertyManagement.Components
{
    public static class OneSignal
    {
        public static async Task Register(string identifier)
        {
            await SendRequest(OneSignalStatus.Subscribed, "identifier", identifier);
        }

        public static async Task Assign(int userId)
        {
            await SendRequest(OneSignalStatus.Subscribed, "tags", new Dictionary<string, object>() { { "user_id", userId } });
        }

        public static async Task Unassign(int userId)
        {
            await SendRequest(OneSignalStatus.Unsubscribed, "tags", new Dictionary<string, object>() { { "user_id", userId } });
        }

        private static async Task SendRequest(OneSignalStatus status, string additionalDataKey, object additionalDataValue)
        {
            var request = new Dictionary<string, object> {
                { "app_id", "f0c7ec9a-8785-4904-aa18-ccbf50c4129a" },
                { "notification_types", status },
                { additionalDataKey, additionalDataValue }
            };

            if (Application.Current.Properties.ContainsKey("OneSignal.Player.ID"))
            {
                var playerId = Application.Current.Properties["OneSignal.Player.ID"];
                await Put($"https://onesignal.com/api/v1/players/{playerId}", request, (response) =>
                {
                    // for debugging
                });
            }
            else
            {
                request.Add("device_type", Device.OnPlatform(0, 1, 3));
                await Post("https://onesignal.com/api/v1/players", request, (response) =>
                {
                    Application.Current.Properties["OneSignal.Player.ID"] = (string)response["id"];
                    Task.Run(async () => await Application.Current.SavePropertiesAsync());
                });
            }
        }

        private static async Task Post(string url, Dictionary<string, object> request, Action<Dictionary<string, object>> successCallback)
        {
            var response = await HttpGateway.Post<Dictionary<string, object>, Dictionary<string, object>>(url, "OGUyMmE4YjQtMTY3Zi00Zjc3LTk0MTAtNTMxZDNlZTBlNDEA", request);
            if (response.ContainsKey("success") && (bool)response["success"] == true) successCallback.Invoke(response);
        }

        private static async Task Put(string url, Dictionary<string, object> request, Action<Dictionary<string, object>> successCallback)
        {
            var response = await HttpGateway.Put<Dictionary<string, object>, Dictionary<string, object>>(url, "OGUyMmE4YjQtMTY3Zi00Zjc3LTk0MTAtNTMxZDNlZTBlNDEA", request);
            if (response.ContainsKey("success") && (bool)response["success"] == true) successCallback.Invoke(response);
        }

        public enum OneSignalStatus
        {
            Subscribed = 1,
            Unsubscribed = -2
        }
    }
}
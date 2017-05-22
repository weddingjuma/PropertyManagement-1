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
			await SendRequest("identifier", identifier);
		}

		public static async Task Assign(int userId)
		{
			await SendRequest("tags", new Dictionary<string, object>() { { "user_id", userId } });
		}

		private static async Task SendRequest(string additionalDataKey, object additionalDataValue)
		{
			var request = new Dictionary<string, object> { 
				{ "app_id", "6e68aad9-e62b-413f-be8f-9fca4ae278ef" },
				{ additionalDataKey, additionalDataValue }
			};

			if (Application.Current.Properties.ContainsKey("OneSignal.Player.ID"))
			{
				var playerId = Application.Current.Properties["OneSignal.Player.ID"];
				await Put($"https://onesignal.com/api/v1/players/{playerId}", request, (response) =>
				{
					int i = 0;
				});
			}
			else
			{
				request.Add("device_type", Device.OnPlatform(0, 1, 3));
				request.Add("notification_types", 1);
				await Post("https://onesignal.com/api/v1/players", request, (response) =>
				{
					Application.Current.Properties["OneSignal.Player.ID"] = (string)response["id"];
					Task.Run(async () => await Application.Current.SavePropertiesAsync());
				});
			}
		}

		private static async Task Post(string url, Dictionary<string, object> request, Action<Dictionary<string, object>> successCallback)
		{
			var response = await HttpGateway.Post<Dictionary<string, object>, Dictionary<string, object>>(url, "MWJkNTdmYzAtZWU4My00NjI0LTk1YzMtMTg5OWE0MTEwYTlh", request);
			if (response.ContainsKey("success") && (bool)response["success"] == true) successCallback.Invoke(response);
		}

		private static async Task Put(string url, Dictionary<string, object> request, Action<Dictionary<string, object>> successCallback)
		{
			var response = await HttpGateway.Put<Dictionary<string, object>, Dictionary<string, object>>(url, "MWJkNTdmYzAtZWU4My00NjI0LTk1YzMtMTg5OWE0MTEwYTlh", request);
			if (response.ContainsKey("success") && (bool)response["success"] == true) successCallback.Invoke(response);
		}
	}
}
using System.Threading.Tasks;
using PropertyManagement.Models;
using Xamarin.Forms;

namespace PropertyManagement.Components
{
	public static class UserActions
	{
		public static async Task<RegisterResponseModel> Register(RegisterRequestModel request)
		{
			var response = await HttpGateway.Post<RegisterRequestModel, RegisterResponseModel>(
				"http://www.wavelinkllc.com/property_management/api/user/register.php",
				request
			);
			if (response.Success) await PersistUser(response.User, request.Password);
			return response;
		}

		public static async Task<LogInResponseModel> LogIn()
		{
			return await LogIn(
				Application.Current.Properties.ContainsKey("User.EmailOrPhone") ? (string)Application.Current.Properties["User.EmailOrPhone"] : string.Empty,
				Application.Current.Properties.ContainsKey("User.Password") ? (string)Application.Current.Properties["User.Password"] : string.Empty
			);
		}

		public static async Task<LogInResponseModel> LogIn(string emailOrPhone, string password)
		{
			var response = await HttpGateway.Post<object, LogInResponseModel>(
				"http://www.wavelinkllc.com/property_management/api/user/login.php",
				new { email_or_phone = emailOrPhone, password = password }
			);
			if (response.Success) await PersistUser(response.User, password);
			return response;
		}

		public static async Task<UserSaveResponseModel> Save()
		{
			var user = ApplicationContext.User;
			var response = await HttpGateway.Post<UserSaveRequestModel, UserSaveResponseModel>("http://www.wavelinkllc.com/property_management/api/user/save.php", new UserSaveRequestModel
			{
				Id = user.Id,
				EmailAddress = user.EmailAddress,
				PhoneNumber = user.PhoneNumber,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PropertyId = user.PropertyId,
				Unit = user.Unit,
				LeaseMonths = user.LeaseMonths
			});
			if (response.Success) await PersistUser(response.User, user.Password);
			return response;
		}

		private static async Task PersistUser(UserModel user, string password)
		{
			ApplicationContext.User = user;
			ApplicationContext.User.Password = password;
			Application.Current.Properties["User.Id"] = user?.Id;
			Application.Current.Properties["User.EmailOrPhone"] = user?.EmailAddress ?? user?.PhoneNumber;
			Application.Current.Properties["User.Password"] = password;
			await Application.Current.SavePropertiesAsync();
			await OneSignal.Assign(user.Id);
		}	
	}
}
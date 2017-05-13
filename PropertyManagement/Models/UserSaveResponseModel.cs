using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class UserSaveResponseModel : BaseResponseModel
	{
		[JsonProperty(PropertyName = "user")]
		public UserModel User { get; set; }
	}
}
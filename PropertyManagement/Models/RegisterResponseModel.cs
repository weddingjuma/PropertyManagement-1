using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class RegisterResponseModel : BaseResponseModel
	{
		[JsonProperty(PropertyName = "user")]
		public UserModel User { get; set; }
	}
}
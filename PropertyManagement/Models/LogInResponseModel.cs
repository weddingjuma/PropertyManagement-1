using System;
using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class LogInResponseModel : BaseResponseModel
	{
		[JsonProperty(PropertyName = "user")]
		public UserModel User { get; set; }
	}
}
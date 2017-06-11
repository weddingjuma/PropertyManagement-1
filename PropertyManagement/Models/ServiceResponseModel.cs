using System;
using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class ServiceResponseModel : BaseResponseModel
	{
		[JsonProperty(PropertyName = "service")]
		public ServiceModel Service { get; set; }
	}
}
using System;
using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class ServiceRequestModel
	{
		[JsonProperty(PropertyName = "tenant_user_id")]
		public int TenantUserId { get; set; }
		[JsonProperty(PropertyName = "type")]
		public ServiceType Type { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
	}
}
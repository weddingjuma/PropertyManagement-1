using System;
using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class ServiceModel
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }
		[JsonProperty(PropertyName = "service_user_name")]
		public string ServiceUserName { get; set; }
		[JsonProperty(PropertyName = "type")]
		public ServiceType Type { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "created_time")]
		public DateTime CreatedTime { get; set; }
		[JsonProperty(PropertyName = "completed_time")]
		public DateTime? CompletionTime { get; set; }
		[JsonProperty(PropertyName = "completion_notes")]
		public string CompletionNotes { get; set; }

		public bool IsAssigned { get { return !string.IsNullOrWhiteSpace(ServiceUserName); } }
		public bool IsCompleted { get { return CompletionTime != null; } }

		public ServiceModel()
		{
		}
	}

	public enum ServiceType
	{
		Plumbing,
		Floors,
		Electrical,
		Windows,
		AirConditioning,
		Lights,
		Appliances,
		Outside,
		Other
	}
}
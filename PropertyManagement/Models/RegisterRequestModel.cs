using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class RegisterRequestModel
	{
		[JsonProperty(PropertyName = "type")]
		public UserType Type { get; set; }
		[JsonProperty(PropertyName = "email_address")]
		public string EmailAddress { get; set; }
		[JsonProperty(PropertyName = "phone_number")]
		public string PhoneNumber { get; set; }
		[JsonProperty(PropertyName = "password")]
		public string Password { get; set; }
		[JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }
		[JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }
		[JsonProperty(PropertyName = "property_id")]
		public int PropertyId { get; set; }
		[JsonProperty(PropertyName = "unit")]
		public string Unit { get; set; }
		[JsonProperty(PropertyName = "lease_months")]
		public int LeaseMonths { get; set; }
	}
}
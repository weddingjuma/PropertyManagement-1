using Newtonsoft.Json;

namespace PropertyManagement.Models
{
	public class BaseResponseModel : BaseModel
	{
		[JsonProperty(PropertyName = "success")]
		public bool Success { get; set; }
		[JsonProperty(PropertyName = "error_code")]
		public int ErrorCode { get; set; }

		public string ErrorMessage
		{
			get
			{
				switch (ErrorCode)
				{
					case 1: return "There was a network/server error. Please try again.";
					case 2: return "There was a database error. Please try again.";
					case 3: return "This email address has already been taken. Please try another.";
					case 4: return "This phone number has already been taken. Please try another.";
					case 5: return "The entered credentials are incorrect. Please try again.";
					default: return "There was a network/server error. Please try again.";
				}
			}
		}
	}
}
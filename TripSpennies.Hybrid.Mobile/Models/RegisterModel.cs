
using System.ComponentModel.DataAnnotations;

namespace TripSpennies.Hybrid.Mobile.Models
{
	public class RegisterModel
	{
		[Required, MaxLength(30)]
		public string Name { get; set; }

		[Required, MaxLength(20)]
		public string Username { get; set; }

		[Required, MaxLength(20)]
		public string Password { get; set; }
	}
}

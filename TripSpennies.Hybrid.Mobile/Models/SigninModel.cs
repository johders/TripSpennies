
using System.ComponentModel.DataAnnotations;

namespace TripSpennies.Hybrid.Mobile.Models
{
	public class SigninModel
	{
        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}

using System.Text.Json;

namespace TripSpennies.Hybrid.Mobile.Models
{
	public readonly record struct LoggedInUser(int Id, string Name)
	{
		public string ToJson() => JsonSerializer.Serialize(this);
	}
}

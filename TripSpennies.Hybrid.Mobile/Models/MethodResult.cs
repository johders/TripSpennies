namespace TripSpennies.Hybrid.Mobile.Models
{
	public readonly record struct MethodResult(bool isSuccess, string? error)
	{
		public static MethodResult Success() => new(true, null);
		public static MethodResult Fail(string? error) => new(false, error);
	}
}

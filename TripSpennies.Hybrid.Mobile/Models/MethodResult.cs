namespace TripSpennies.Hybrid.Mobile.Models
{
	public readonly record struct MethodResult(bool IsSuccess, string? Error)
	{
		public static MethodResult Success() => new(true, null);
		public static MethodResult Fail(string? error) => new(false, error);
	}
}

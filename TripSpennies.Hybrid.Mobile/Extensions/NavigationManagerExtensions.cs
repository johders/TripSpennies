using Microsoft.AspNetCore.Components;

namespace TripSpennies.Hybrid.Mobile.Extensions
{
	public static class NavigationManagerExtensions
	{
		public static string GetCurrentPageUrl(this NavigationManager navManager)
		{
			return $"/{navManager.Uri.Replace(navManager.BaseUri, "").TrimStart('/')}";
		}
		public static void GoToInnerPage(this NavigationManager navManager, string innerPageUrl)
		{
			navManager.NavigateTo(innerPageUrl, new NavigationOptions
			{
				HistoryEntryState = navManager.GetCurrentPageUrl()
			});
		}

		public static void GoBack(this NavigationManager navManager, string? fallbackUrl = "/homepage")
		{
			var previousPageUrl = navManager.HistoryEntryState ?? fallbackUrl;

			navManager.NavigateTo(previousPageUrl, new NavigationOptions
			{
				HistoryEntryState = null,
				ReplaceHistoryEntry = true
			});
		}
	}
}

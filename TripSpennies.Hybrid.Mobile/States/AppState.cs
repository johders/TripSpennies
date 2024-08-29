namespace TripSpennies.Hybrid.Mobile.States
{
	public class AppState
	{

		public event EventHandler<string> SelectedMenuItemChangedEvent;
		public string SelectedMenuItem { get; private set; } = AppConstants.MenuItems.Home;
		public string PageTitle => SelectedMenuItem switch
		{
			AppConstants.MenuItems.Home => AppConstants.AppName,
			_ => SelectedMenuItem
		};

        public void SetSelectedMenuItem(string pageName)
		{
			SelectedMenuItem = pageName;
			SelectedMenuItemChangedEvent?.Invoke(this, pageName);
		}
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TripSpennies.Hybrid.Mobile.States
{
	public class AppState : INotifyPropertyChanged
	{

		//public event EventHandler<string> SelectedMenuItemChangedEvent;
		public event PropertyChangedEventHandler? PropertyChanged;

		public string SelectedMenuItem { get; private set; } = AppConstants.MenuItems.Home;
		public string PageTitle => SelectedMenuItem switch
		{
			AppConstants.MenuItems.Home => AppConstants.AppName,
			_ => SelectedMenuItem
		};

		private string _innerPageTitle = string.Empty;
        public string InnerPageTitle 
		{
			get => _innerPageTitle;
			private set
			{
				_innerPageTitle = value;
				Notify();
			} 
		}

        public void SetSelectedMenuItem(string pageName)
		{
			SelectedMenuItem = pageName;
			//SelectedMenuItemChangedEvent?.Invoke(this, pageName);
			Notify(nameof(SelectedMenuItem));
		}

		public void SetInnerPageTitle(string pageName)
		{
			//Can do it via the full prop or the method in setselectedmenuitem
			InnerPageTitle = pageName;
		}

		private void Notify([CallerMemberName]string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}

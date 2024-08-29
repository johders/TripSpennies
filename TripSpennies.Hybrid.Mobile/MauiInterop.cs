
namespace TripSpennies.Hybrid.Mobile
{
	public class MauiInterop
	{
		private readonly AppViewModel _appViewModel;

        public MauiInterop(AppViewModel appViewModel)
        {
            _appViewModel = appViewModel;
        }

        public void ShowLoader() => _appViewModel.ToggleIsBusy(true);
        public void HideLoader() => _appViewModel.ToggleIsBusy(false);

        public async Task ShowErrorAlertAsync(string message, string? title = "Error") => await App.Current.MainPage.DisplayAlert(title, message, "Ok");
		public async Task ShowSuccessAlertAsync(string message, string? title = "Success") => await App.Current.MainPage.DisplayAlert(title, message, "Ok");

        public bool IsAndroid => DeviceInfo.Current.Platform == DevicePlatform.Android;
        public bool IsIos => DeviceInfo.Current.Platform == DevicePlatform.iOS;

    }
}

﻿using System.ComponentModel;

namespace TripSpennies.Hybrid.Mobile.ViewModels
{
	public class AppViewModel : INotifyPropertyChanged
	{
		private bool _isBusy = true;

		public event PropertyChangedEventHandler? PropertyChanged;

		public bool IsBusy
		{
			get => _isBusy;
			private set
			{
				if (_isBusy != value)
				{
					{
						_isBusy = value;
						PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
					}
				}
			}
		}

		public void ToggleIsBusy(bool isBusy)
		{
			IsBusy = isBusy;
		}
	}
}

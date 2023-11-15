﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SetterBug
{
	public abstract class RaisableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void SetProperty<T>(ref T property, T value, Action onValueChanged, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(property, value))
				return;

			property = value;
			onValueChanged?.Invoke();
			RaisePropertyChanged(propertyName);
		}

		protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
			=> SetProperty(ref property, value, null, propertyName);

		protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
#region References
using System.Collections.Generic;
using System.ComponentModel;
#endregion

public class ReactiveObject
{
	public event PropertyChangedEventHandler PropertyChanged;

	public void NotifyDirty () { Notify(null); }

	protected bool SetProperty<T> (ref T x, T value, string property)
	{
		if (EqualityComparer<T>.Default.Equals(x, value)) return false;
		x = value;
		Notify(property);
		return true;
	}

	protected virtual void Notify (string propertyName)
	{
		if (PropertyChanged == null) return;
		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	}
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.ComponentModel
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T propertyBackStore, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (Equals(propertyBackStore, newValue))
                return false;

            propertyBackStore = newValue;
            if (PropertyChanged != null)
                PropertyChanged(this,
                                new PropertyChangedEventArgs(propertyName)
                                );

            return true;
        }
    }
}
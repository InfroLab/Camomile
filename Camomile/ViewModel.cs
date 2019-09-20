using System.ComponentModel;
using System.Runtime.CompilerServices;


/// <summary>
/// This is a base class implementing property change notification.
/// </summary>


namespace Camomile
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

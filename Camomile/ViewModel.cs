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

        private string address;

        public string Address
        {
            //The list showing collection contents
            //is not updating without this notification
            get
            {
                return address;
            }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
    }
}

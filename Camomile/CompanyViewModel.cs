using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Camomile
{
    public class CompanyViewModel : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string contractStatus;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string ContractStatus
        {
            get
            {
                return contractStatus;
            }
            set
            {
                if (contractStatus != value)
                {
                    contractStatus = value;
                    OnPropertyChanged("ContractStatus");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

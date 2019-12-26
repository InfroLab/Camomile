namespace Camomile
{
    public class GasPlantViewModel : ViewModel
    {
        private int id;
        private string address;
        private string features;

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
        public string Address
        {
            get
            {return address;}
            set
            {if (address != value){ address = value; OnPropertyChanged("Address");}}
        }
        public string Features
        {
            get
            { return features; }
            set
            { if (features != value) { features = value; OnPropertyChanged("Features"); } }
        }
    }
}

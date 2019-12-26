namespace Camomile
{
    public class FlatViewModel : ViewModel
    {
        private int id;
        private string address;
        private int rooms;
        private string renter;
        private int registration;
        private int area;
        private int areaPerPerson;
        private string balcony;

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
            { return address; }
            set
            { if (address != value) { address = value; OnPropertyChanged("Address"); } }
        }
        public int Rooms
        {
            get
            { return rooms; }
            set
            { if (rooms != value) { rooms = value; OnPropertyChanged("Rooms"); } }
        }
        public string Renter
        {
            get
            { return renter; }
            set
            { if (renter != value) { renter = value; OnPropertyChanged("Renter"); } }
        }
        public int Registration
        {
            get
            { return registration; }
            set
            { if (registration != value) { registration = value; OnPropertyChanged("Registration"); } }
        }
        public int Area
        {
            get
            { return area; }
            set
            { if (area != value) { area = value; OnPropertyChanged("Area"); } }
        }
        public int AreaPerPerson
        {
            get
            { return areaPerPerson; }
            set
            { if (areaPerPerson != value) { areaPerPerson = value; OnPropertyChanged("AreaPerPerson"); } }
        }
        public string Balcony
        {
            get
            { return balcony; }
            set
            { if (balcony != value) { balcony = value; OnPropertyChanged("Balcony"); } }
        }
    }
}

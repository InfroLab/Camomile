namespace Camomile
{
    public class HouseViewModel : ViewModel
    {
        private int id;
        private string address;
        private int entranceNumber;
        private int floors;
        private int flats;
        private string elevator;
        private string hotWater;
        private string coldWater;
        private string gas;
        private string antenna;
        private string cabelTV;
        private string telephone;
        private string radio;
        private string projectNumber;
        private string settlement;
        private string delivery;

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
        public int EntranceNumber
        {
            get
            { return entranceNumber; }
            set
            { if (entranceNumber != value) { entranceNumber = value; OnPropertyChanged("EntranceNumber"); } }
        }
        public int Floors
        {
            get
            { return floors; }
            set
            { if (floors != value) { floors = value; OnPropertyChanged("Floors"); } }
        }
        public int Flats
        {
            get
            { return flats; }
            set
            { if (flats != value) { flats = value; OnPropertyChanged("Flats"); } }
        }
        public string Elevator
        {
            get
            { return elevator; }
            set
            { if (elevator != value) { elevator = value; OnPropertyChanged("Elevator"); } }
        }
        public string HotWater
        {
            get
            { return hotWater; }
            set
            { if (hotWater != value) { hotWater = value; OnPropertyChanged("HotWater"); } }
        }
        public string ColdWater
        {
            get
            { return coldWater; }
            set
            { if (coldWater != value) { coldWater = value; OnPropertyChanged("ColdWater"); } }
        }
        public string Gas
        {
            get
            { return gas; }
            set
            { if (gas != value) { gas = value; OnPropertyChanged("Gas"); } }
        }
        public string Antenna
        {
            get
            { return antenna; }
            set
            { if (antenna != value) { antenna = value; OnPropertyChanged("Antenna"); } }
        }
        public string CabelTV
        {
            get
            { return cabelTV; }
            set
            { if (cabelTV != value) { cabelTV = value; OnPropertyChanged("CabelTV"); } }
        }
        public string Telephone
        {
            get
            { return telephone; }
            set
            { if (telephone != value) { telephone = value; OnPropertyChanged("Telephone"); } }
        }
        public string Radio
        {
            get
            { return radio; }
            set
            { if (radio != value) { radio = value; OnPropertyChanged("Radio"); } }
        }
        public string ProjectNumber
        {
            get
            { return projectNumber; }
            set
            { if (projectNumber != value) { projectNumber = value; OnPropertyChanged("ProjectNumber"); } }
        }
        public string Settlement
        {
            get
            { return settlement; }
            set
            { if (settlement != value) { settlement = value; OnPropertyChanged("Settlement"); } }
        }
        public string Delivery
        {
            get
            { return delivery; }
            set
            { if (delivery != value) { delivery = value; OnPropertyChanged("Delivery"); } }
        }
    }
}

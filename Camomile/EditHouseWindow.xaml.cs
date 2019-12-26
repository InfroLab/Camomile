using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Camomile
{
    /// <summary>
    /// Логика взаимодействия для AddCompanyWindow.xaml
    /// </summary>
    public partial class EditHouseWindow : Window
    {
        public EditHouseWindow(int id, string address, int entranceNumber, int floors, int flats, string elevator, string hotWater, string coldWater, string gas, string antenna, string cabelTV, string telephone, string radio, string projectNumber, string settlement, string delivery)
        {
            InitializeComponent();
            Id = id;
            Address = address;
            EntranceNumber = entranceNumber;
            Floors = floors;
            Flats = flats;
            Elevator = elevator;
            HotWater = hotWater;
            ColdWater = coldWater;
            Gas = gas;
            Antenna = antenna;
            CabelTV = cabelTV;
            Telephone = telephone;
            Radio = radio;
            ProjectNumber = projectNumber;
            Settlement = settlement;
            Delivery = delivery;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public int Id {get;set;}
        public string Address
        {
            get{ return AddressBox.Text; }
            set { AddressBox.Text = value; }
        }
        public int EntranceNumber
        {
            get{ return Convert.ToInt32(EntranceBox.Text); }
            set { EntranceBox.Text = Convert.ToString(value); }
        }
        public int Floors
        {
            get{ return Convert.ToInt32(FloorsBox.Text); }
            set { FloorsBox.Text = Convert.ToString(value); }
        }
        public int Flats
        {
            get{ return Convert.ToInt32(FlatsBox.Text); }
            set { FlatsBox.Text = Convert.ToString(value); }
        }
        public string Elevator
        {
            get{ return ElevatorBox.Text; }
            set { ElevatorBox.Text = value; }
        }
        public string HotWater
        {
            get{ return HotWaterBox.Text; }
            set { HotWaterBox.Text = value; }
        }
        public string ColdWater
        {
            get{ return ColdWaterBox.Text; }
            set { ColdWaterBox.Text = value; }
        }
        public string Gas
        {
            get{ return GasBox.Text; }
            set { GasBox.Text = value; }
        }
        public string Antenna
        {
            get{ return AntennaBox.Text; }
            set { AntennaBox.Text = value; }
        }
        public string CabelTV
        {
            get{ return CabelTVBox.Text; }
            set { CabelTVBox.Text = value; }
        }
        public string Telephone
        {
            get{ return TelephoneBox.Text; }
            set { TelephoneBox.Text = value; }
        }
        public string Radio
        {
            get{ return RadioBox.Text; }
            set { RadioBox.Text = value; }
        }
        public string ProjectNumber
        {
            get{ return ProjectBox.Text; }
            set { ProjectBox.Text = value; }
        }
        public string Settlement
        {
            get{ return SettlementBox.Text; }
            set { SettlementBox.Text = value; }
        }
        public string Delivery
        {
            get{ return DeliveryBox.Text; }
            set { DeliveryBox.Text = value; }
        }


    }
}

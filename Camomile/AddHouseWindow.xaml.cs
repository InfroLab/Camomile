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
    public partial class AddHouseWindow : Window
    {
        public AddHouseWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string Address
        {
            get
            { return AddressBox.Text; }
        }
        public int EntranceNumber
        {
            get
            { return Convert.ToInt32(EntranceBox.Text); }
        }
        public int Floors
        {
            get
            { return Convert.ToInt32(FloorsBox.Text); }
        }
        public int Flats
        {
            get
            { return Convert.ToInt32(FlatsBox.Text); }
        }
        public string Elevator
        {
            get
            { return ElevatorBox.Text; }
        }
        public string HotWater
        {
            get
            { return HotWaterBox.Text; }
        }
        public string ColdWater
        {
            get
            { return ColdWaterBox.Text; }
        }
        public string Gas
        {
            get
            { return GasBox.Text; }
        }
        public string Antenna
        {
            get
            { return AntennaBox.Text; }
        }
        public string CabelTV
        {
            get
            { return CabelTVBox.Text; }
        }
        public string Telephone
        {
            get
            { return TelephoneBox.Text; }
        }
        public string Radio
        {
            get
            { return RadioBox.Text; }
        }
        public string ProjectNumber
        {
            get
            { return ProjectBox.Text; }
        }
        public string Settlement
        {
            get
            { return SettlementBox.Text; }
        }
        public string Delivery
        {
            get
            { return DeliveryBox.Text; }
        }


    }
}

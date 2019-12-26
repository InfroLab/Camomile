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
    public partial class AddFlatWindow : Window
    {
        public AddFlatWindow()
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
        public int Rooms
        {
            get
            { return Convert.ToInt32(RoomsBox.Text); }
        }
        public string Renter
        {
            get
            { return RenterBox.Text; }
        }
        public int Registration
        {
            get
            { return Convert.ToInt32(RegistrationBox.Text); }
        }
        public int Area
        {
            get
            { return Convert.ToInt32(AreaBox.Text); }
        }
        public int AreaPerPerson
        {
            get
            { return Convert.ToInt32(AreaPerPersonBox.Text); }
        }
        public string Balcony
        {
            get
            { return BalconyBox.Text; }
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace Camomile
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HouseStack.DataContext = new HousesListViewModel();
            ElectricSubStack.DataContext = new ElectricSubsListViewModel();
            GasPlantStack.DataContext = new GasPlantsListViewModel();
            FlatStack.DataContext = new FlatsListViewModel();
        }

    }
}

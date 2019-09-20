using System.Windows;

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

            CompanyColumn.DataContext = new CompaniesListViewModel();
            UserColumn.DataContext = new UsersListViewModel();
        }
    }
}

using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    public class CompaniesListViewModel : ViewModel
    {
        private CompanyViewModel selectedCompany;

        public ObservableCollection<CompanyViewModel> Companies { get; set; }
        public CompanyViewModel SelectedCompany
        {
            get
            {
                return selectedCompany;
            }
            set
            {
                if (selectedCompany != value)
                {
                    selectedCompany = value;
                    OnPropertyChanged("SelectedCompany");
                }
            }
        }

        public CompaniesListViewModel()
        {
            Companies = new ObservableCollection<CompanyViewModel>
            {
                new CompanyViewModel {Id = 1, Name="Test1", ContractStatus="Opened"},
                new CompanyViewModel {Id = 2, Name="Test2", ContractStatus="Unsigned"},
                new CompanyViewModel {Id = 3, Name="Test3", ContractStatus="Closed"}
            };
            AddCompanyCommand = new Command(
                execute: (obj) =>
                {
                    AddCompanyWindow addCompanyWindow = new AddCompanyWindow();

                    if (addCompanyWindow.ShowDialog() == true)
                    {
                        if (addCompanyWindow.Name != "" && addCompanyWindow.ContractStatus != "")
                        {
                            int latest_id = Companies[Companies.Count - 1].Id + 1;
                            Companies.Add
                            (
                                new CompanyViewModel { Id = latest_id, Name = addCompanyWindow.Name, ContractStatus = addCompanyWindow.ContractStatus }
                                );
                        }
                        else
                        {
                            MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to add a new user!", "Error!", MessageBoxButton.OK);
                    }
                }
                );

            DeleteCompanyCommand = new Command(
                execute: (obj) =>
                {
                    Companies.Remove(SelectedCompany);
                    //TO-DO: Очистить сетку пользователей
                    //TO-DO: Удалить всех связанных пользователей
                }
                );

            EditCompanyCommand = new Command(
                execute: (obj) =>
                {
                    if (selectedCompany != null)
                    {
                        EditCompanyWindow editCompanyWindow = new EditCompanyWindow(SelectedCompany.Id, SelectedCompany.Name, SelectedCompany.ContractStatus);
                        int editIndex = Companies.IndexOf(SelectedCompany);

                        if (editCompanyWindow.ShowDialog() == true)
                        {
                            if (editCompanyWindow.Name != "" && editCompanyWindow.ContractStatus != "")
                            {
                                SelectedCompany.Id = editCompanyWindow.Id;
                                SelectedCompany.Name = editCompanyWindow.Name;
                                SelectedCompany.ContractStatus = editCompanyWindow.ContractStatus;
                            }
                            else
                            {
                                MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to edit company!", "Error!", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select the company entry!", "Error!", MessageBoxButton.OK);
                    }

                }
                );
        }

        public Command AddCompanyCommand { private set; get; }
        public Command DeleteCompanyCommand { private set; get; }
        public Command EditCompanyCommand { private set; get; }
    }
}

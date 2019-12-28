using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    public class CompaniesListViewModel : ViewModel
    {
        private CompanyViewModel selectedCompany;
        private ObservableCollection<CompanyViewModel> companies;

        public ObservableCollection<CompanyViewModel> Companies
        {
            //The list showing collection contents
            //is not updating without this notification
            get
            {
                return companies;
            }
            set
            {
                if (companies != value)
                {
                    companies = value;
                    OnPropertyChanged("Companies");
                }
            }
        }
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
                if(value != null)
                {
                    Database.GetUsersByCompany(value.Id);
                    if (SelectedCompany.ContractStatus == "Opened")
                    {
                        UsersListViewModel.CurrentCompanyId = value.Id;
                        UsersListViewModel.CurrentCompanyStatus = value.ContractStatus;
                    }
                }
                else
                {
                    //Clearing the list since there is no selected company
                    UsersListViewModel.Users.Clear();
                }
            }
        }

        public CompaniesListViewModel()
        {
            Companies = Database.GetCompanies();

            AddCompanyCommand = new Command(
                execute: (obj) =>
                {
                    AddCompanyWindow addCompanyWindow = new AddCompanyWindow();

                    if (addCompanyWindow.ShowDialog() == true)
                    {
                        if (addCompanyWindow.Name != "" && addCompanyWindow.ContractStatus != "")
                        {
                            Database.AddCompany(new Company { Name = addCompanyWindow.Name, ContractStatus = addCompanyWindow.ContractStatus });
                            Companies = Database.GetCompanies();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                        }
                    }
                }
                );

            DeleteCompanyCommand = new Command(
                execute: (obj) =>
                {
                    if(SelectedCompany != null)
                    {
                        Database.RemoveCompany(SelectedCompany.Id);
                        Companies = Database.GetCompanies();
                        UsersListViewModel.CurrentCompanyId = 0;
                        UsersListViewModel.CurrentCompanyStatus = "";
                    }
                    else
                    {
                        MessageBox.Show("Select the company entry!", "Error!", MessageBoxButton.OK);
                    }
                }
                );

            EditCompanyCommand = new Command(
                execute: (obj) =>
                {
                    if (selectedCompany != null)
                    {
                        EditCompanyWindow editCompanyWindow = new EditCompanyWindow(SelectedCompany.Id, SelectedCompany.Name, SelectedCompany.ContractStatus);

                        if (editCompanyWindow.ShowDialog() == true)
                        {
                            if (editCompanyWindow.Name != "" && editCompanyWindow.ContractStatus != "")
                            {
                                Database.UpdateCompany(new Company { Id = editCompanyWindow.Id, ContractStatus = editCompanyWindow.ContractStatus, Name = editCompanyWindow.Name });
                                UsersListViewModel.CurrentCompanyStatus = editCompanyWindow.ContractStatus;
                                Companies = Database.GetCompanies();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select the company entry!", "Error!", MessageBoxButton.OK);
                        }

                    }
                }
                );
        }

        public Command AddCompanyCommand { private set; get; }
        public Command DeleteCompanyCommand { private set; get; }
        public Command EditCompanyCommand { private set; get; }
    }
}

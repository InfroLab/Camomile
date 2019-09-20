using System.Collections.ObjectModel;

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
                new CompanyViewModel {Id = 2, Name="Test2", ContractStatus="Not signed"},
                new CompanyViewModel {Id = 3, Name="Test3", ContractStatus="Closed"}
            };
        }
    }
}

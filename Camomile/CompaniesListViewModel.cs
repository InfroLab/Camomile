using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Camomile
{
    public class CompaniesListViewModel : INotifyPropertyChanged
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
                new CompanyViewModel {Id = 2, Name="Test2", ContractStatus="Closed"}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

namespace Camomile
{
    public class CompanyViewModel : ViewModel
    {
        private int id;
        private string name;
        private string contractStatus;

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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string ContractStatus
        {
            get
            {
                return contractStatus;
            }
            set
            {
                if (contractStatus != value)
                {
                    contractStatus = value;
                    OnPropertyChanged("ContractStatus");
                }
            }
        }
    }
}

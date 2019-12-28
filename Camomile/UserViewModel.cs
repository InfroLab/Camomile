namespace Camomile
{
    public class UserViewModel : ViewModel
    {
        private string name;
        private string login;
        private string password;
        private int companyId;

        public int Id { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public int CompanyId
        {
            get
            {
                return companyId;
            }
            set
            {
                if (companyId != value)
                {
                    companyId = value;
                    OnPropertyChanged("CompanyId");
                }
            }
        }

    }
}

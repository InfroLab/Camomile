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
    class UsersListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UserViewModel> users = new ObservableCollection<UserViewModel>();
        private UserViewModel selectedUser;
        public ObservableCollection<UserViewModel> Users
        {
            get
            {
                return users;
            }
            set
            {
                if(users != value)
                {
                    users = value;
                    OnPropertyChanged("Users");
                }

            }
        }
        public UserViewModel SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                if (selectedUser !=value)
                {
                    selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                }
            }
        }
        public UsersListViewModel()
        {
            Users = new ObservableCollection<UserViewModel>()
            {
                new UserViewModel{Id=1, Name="Ivanov Ivan", Login="II", Password="12345", CompanyId=1},
                new UserViewModel{Id=2, Name="Petrov Ivan", Login="PI", Password="67890", CompanyId=2}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

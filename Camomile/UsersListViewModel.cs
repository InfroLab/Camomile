using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    class UsersListViewModel : ViewModel
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

            AddUserCommand = new Command(
                execute: (obj) =>
                {
                    AddUserWindow addUserWindow = new AddUserWindow();

                    if(addUserWindow.ShowDialog() == true)
                    {
                        if(addUserWindow.Name != "" && addUserWindow.Login != "" && addUserWindow.Password != "" && addUserWindow.CompanyID > -1)
                        {
                            int latest_id = Users[Users.Count - 1].Id + 1;
                            Users.Add
                            (
                                new UserViewModel { Id = latest_id, Name = addUserWindow.Name, Login = addUserWindow.Login, Password = addUserWindow.Password, CompanyId = addUserWindow.CompanyID }
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
            DeleteUserCommand = new Command(
                execute: (obj) =>
                {
                    Users.Remove(SelectedUser);
                }
                );
            EditUserCommand = new Command(
                execute: (obj) =>
                {
                    EditUserWindow editUserWindow = new EditUserWindow(SelectedUser.Id, SelectedUser.Name, SelectedUser.Login, SelectedUser.Password, SelectedUser.CompanyId);
                    int editIndex = Users.IndexOf(SelectedUser);

                    if (editUserWindow.ShowDialog() == true)
                    {
                        if (editUserWindow.Name != "" && editUserWindow.Login != "" && editUserWindow.Password != "" && editUserWindow.CompanyID > -1)
                        {
                            SelectedUser.Id = editUserWindow.Id;
                            SelectedUser.Name = editUserWindow.Name;
                            SelectedUser.Login = editUserWindow.Login;
                            SelectedUser.Password = editUserWindow.Password;
                            SelectedUser.CompanyId = editUserWindow.CompanyID;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to edit user!", "Error!", MessageBoxButton.OK);
                    }
                }
                );
        }

        public Command AddUserCommand { private set; get; }
        public Command DeleteUserCommand { private set; get; }
        public Command EditUserCommand { private set; get; }
    }
}

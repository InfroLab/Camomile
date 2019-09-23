using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    class UsersListViewModel : ViewModel
    {
        private UserViewModel selectedUser;
        public static ObservableCollection<UserViewModel> Users { get; set; }
        public static int CurrentCompanyId;
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
            AddUserCommand = new Command(
                execute: (obj) =>
                {
                    AddUserWindow addUserWindow = new AddUserWindow();

                    if(addUserWindow.ShowDialog() == true)
                    {
                        if(addUserWindow.Name != "" && addUserWindow.Login != "" && addUserWindow.Password != "" && addUserWindow.CompanyId > -1)
                        {
                            Database.AddUser(new User { Name = addUserWindow.Name, Login = addUserWindow.Login, Password = addUserWindow.Password, CompanyId = addUserWindow.CompanyId });
                            Database.GetUsersByCompany(CurrentCompanyId);
                        }
                        else
                        {
                            MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                        }
                    }
                }
                );
            DeleteUserCommand = new Command(
                execute: (obj) =>
                {
                    if (SelectedUser != null)
                    {
                        Database.RemoveUser(SelectedUser.Id);
                        Database.GetUsersByCompany(CurrentCompanyId);
                    }
                }
                );
            EditUserCommand = new Command(
                execute: (obj) =>
                {
                    if (selectedUser != null)
                    {
                        EditUserWindow editUserWindow = new EditUserWindow(SelectedUser.Id, SelectedUser.Name, SelectedUser.Login, SelectedUser.Password, SelectedUser.CompanyId);
                        int editIndex = Users.IndexOf(SelectedUser);

                        if (editUserWindow.ShowDialog() == true)
                        {
                            if (editUserWindow.Name != "" && editUserWindow.Login != "" && editUserWindow.Password != "" && editUserWindow.CompanyId > -1)
                            {
                                Database.UpdateUser(new User { Id = editUserWindow.Id, Name = editUserWindow.Name, Login = editUserWindow.Login, Password = editUserWindow.Password, CompanyId = editUserWindow.CompanyId });
                                Database.GetUsersByCompany(CurrentCompanyId);
                            }
                            else
                            {
                                MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select the user entry!", "Error!", MessageBoxButton.OK);
                    }

                }
                );
        }

        public Command AddUserCommand { private set; get; }
        public Command DeleteUserCommand { private set; get; }
        public Command EditUserCommand { private set; get; }
    }
}

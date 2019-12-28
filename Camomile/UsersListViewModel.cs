using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    class UsersListViewModel : ViewModel
    {
        private UserViewModel selectedUser;
        public static ObservableCollection<UserViewModel> Users { get; set; }
        public static int CurrentCompanyId = 0;
        public static string CurrentCompanyStatus = "";
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
            Users = new ObservableCollection<UserViewModel>();
            AddUserCommand = new Command(
                execute: (obj) =>
                {
                    if (CurrentCompanyId == 0)
                    {
                        MessageBox.Show("Select company first!", "Error!", MessageBoxButton.OK);
                    }
                    else if (CurrentCompanyStatus != "Opened")
                    {
                        MessageBox.Show("Selected company does not have an opened contract.!", "Error!", MessageBoxButton.OK);
                    }
                    else
                    {
                        AddUserWindow addUserWindow = new AddUserWindow();

                        if (addUserWindow.ShowDialog() == true)
                        {
                            if (addUserWindow.Name != "" && addUserWindow.Login != "" && addUserWindow.Password != "")
                            {
                                Database.AddUser(new User { Name = addUserWindow.Name, Login = addUserWindow.Login, Password = addUserWindow.Password, CompanyId = CurrentCompanyId });
                                Database.GetUsersByCompany(CurrentCompanyId);
                            }
                            else
                            {
                                MessageBox.Show("Incorrect input values!", "Error!", MessageBoxButton.OK);
                            }
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
                    else
                    {
                        MessageBox.Show("Select the user entry!", "Error!", MessageBoxButton.OK);
                    }
                }
                );
            EditUserCommand = new Command(
                execute: (obj) =>
                {
                    if (selectedUser != null)
                    {
                        EditUserWindow editUserWindow = new EditUserWindow(SelectedUser.Id, SelectedUser.Name, SelectedUser.Login, SelectedUser.Password);

                        if (editUserWindow.ShowDialog() == true)
                        {
                            if (editUserWindow.Name != "" && editUserWindow.Login != "" && editUserWindow.Password != "")
                            {
                                Database.UpdateUser(new User { Id = editUserWindow.Id, Name = editUserWindow.Name, Login = editUserWindow.Login, Password = editUserWindow.Password, CompanyId = CurrentCompanyId });
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

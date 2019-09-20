using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Camomile
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow(int id, string name, string login, string password, int companyId)
        {
            InitializeComponent();
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            CompanyID = companyId;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        public int Id;
        public string Name
        {
            get { return NameBox.Text; }
            set { NameBox.Text = value; }
        }
        public string Login
        {
            get { return LoginBox.Text; }
            set { LoginBox.Text = value; }
        }
        public string Password
        {
            get { return PasswordBox.Text; }
            set { PasswordBox.Text = value; }
        }
        public int CompanyID
        {
            get { return Convert.ToInt32(CompanyIDBox.Text); }
            set { CompanyIDBox.Text = Convert.ToString(value); }
        }
    }
}

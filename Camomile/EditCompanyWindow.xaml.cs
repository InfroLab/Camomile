using System;
using System.Windows;

namespace Camomile
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditCompanyWindow : Window
    {
        public EditCompanyWindow(int id, string name, string contractStatus)
        {
            InitializeComponent();
            Id = id;
            Name = name;
            ContractStatus = contractStatus;
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
        public string ContractStatus
        {
            get { return ContractStatusCombo.Text; }
            set { ContractStatusCombo.Text = value; }
        }
    }
}

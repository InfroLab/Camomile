﻿using System;
using System.Windows;

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
﻿using System;
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
    /// Логика взаимодействия для AddCompanyWindow.xaml
    /// </summary>
    public partial class AddGasPlantWindow : Window
    {
        public AddGasPlantWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string Address
        {
            get
            { return AddressBox.Text; }
        }

        public string Features
        {
            get
            { return FeaturesBox.Text; }
        }
    }
}

﻿using StudentManager.ViewModels;
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

namespace StudentManager.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeView.xaml
    /// </summary>
    public partial class AddEmployeeView : Window
    {
        private HomeViewModel _homeViewModel;
        public AddEmployeeView(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            _homeViewModel = homeViewModel;
            var contextDB = ((App)Application.Current).GetContextDB();
            this.DataContext = new AddEmployeeViewModel(_homeViewModel, contextDB);
            _homeViewModel = homeViewModel;
        }
    }
}

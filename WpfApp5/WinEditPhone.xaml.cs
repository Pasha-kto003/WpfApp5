using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для WinEditPhone.xaml
    /// </summary>
    public partial class WinEditPhone : Window
    {
        private readonly Phone phone;

        public WinEditPhone(Phone phone)
        {
            InitializeComponent();
            this.phone = phone;
            DataContext = phone;
        }

        private void SavePhone(object sender, RoutedEventArgs e)
        {
            phone.SaveJson();
            Close();
        }
    }
}

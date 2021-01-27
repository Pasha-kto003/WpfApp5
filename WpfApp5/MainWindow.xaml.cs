using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string searchText;

        public string SearchText { get => searchText; set { searchText = value; Data.FillResultsBySearch(Results, searchText); } }
        public Phone SelectedPhone { get; set; }
        public ObservableCollection<Phone> Results { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Results = Data.GetAllPhones();
            DataContext = this;
        }

        private void CreatePhone(object sender, RoutedEventArgs e)
        {
            new WinEditPhone(Data.CreateNewPhone()).Show();
        }

        private void EditPhone(object sender, RoutedEventArgs e)
        {
            if (SelectedPhone == null)
                return;
            new WinEditPhone(SelectedPhone).Show();
        }

        private void RemovePhone(object sender, RoutedEventArgs e)
        {
            if (SelectedPhone == null)
                return;
            Data.RemovePhone(SelectedPhone);
            Results.Remove(SelectedPhone);
        }
    }
}

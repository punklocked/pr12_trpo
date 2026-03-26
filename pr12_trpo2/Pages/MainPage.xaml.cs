using pr12_trpo2.Service;
using pr12_trpo2.Data;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr12_trpo2.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public UserService service { get; set; } = new();

        public Users? user { get; set; } = null;
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите запись");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(user);
            }
        }

        private void Edit(object sender, MouseButtonEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка");
                return;
            }
            NavigationService.Navigate(new UserFormPage(user));
        }
    }
}

using pr12_trpo2.Service;
using pr12_trpo2.Data;
using pr12_trpo2.ValidationRules;

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
using pr12_trpo2.ValidationRules;

namespace pr12_trpo2.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserFormPage.xaml
    /// </summary>
    public partial class UserFormPage : Page
    {
        private UserService _service = new();
        public Users _user = new();
        public static Users EditingUser { get; set; }
        bool isEdit = false;

        public UserFormPage(Users? _editUser = null)
        {
            InitializeComponent();
            if (_editUser != null )
            {
                _user = _editUser;
                isEdit = true;
                EditingUser = _user;
            }
            DataContext = _user;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationCheck())
            {
                if (isEdit)
                    _service.Commit();
                else
                    _service.Add(_user);

                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Исправьте ошибки валидации");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private bool ValidationCheck()
        {
            bool isValid = true;

            if (Validation.GetHasError(loginTBox) || Validation.GetHasError(nameTBox) || Validation.GetHasError(emailTBox) || Validation.GetHasError(passTBox) || Validation.GetHasError(dateTBox))
                isValid = false;

            return isValid;
        }
    }
}

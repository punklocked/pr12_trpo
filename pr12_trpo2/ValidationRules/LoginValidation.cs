using pr12_trpo2.Data;
using pr12_trpo2.Service;
using pr12_trpo2.Pages;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_trpo2.ValidationRules
{
    public class LoginValidation : ValidationRule
    {
        public static bool IsUnique(string input)
        {
            if (input != string.Empty)
            foreach (Users user in UserService.Users)
            {
                if (user.Login.ToLower() == input.ToLower() && user.Id != UserFormPage.EditingUser?.Id)
                    return false;
            }
            return true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();

            if (input == string.Empty)
                return new ValidationResult(false, "Значение не может быть пустым");

            if (!IsUnique(input))
                return new ValidationResult(false, "Данный логин уже занят");

            if (input.Length < 5)
                return new ValidationResult(false, "Логин должен состоять минимум из 5 символов");

            if (input.Length > 50)
                return new ValidationResult(false, "Логин должен быть не более 50 символов");

            return ValidationResult.ValidResult;
        }
    }
}

using pr12_trpo2.Data;
using pr12_trpo2.Pages;
using pr12_trpo2.Service;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_trpo2.ValidationRules
{
    public class EmailValidation : ValidationRule
    {
        public static bool IsUnique(string input)
        {
            foreach (Users user in UserService.Users)
            {
                if (user.Email.ToLower() == input.ToLower() && user.Id != UserFormPage.EditingUser?.Id)
                    return false;
            }
            return true;
        }

        public static bool CheckEmail(string input)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.+[^@\s]+$";
            return Regex.IsMatch(input, pattern);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();

            if (input == string.Empty)
                return new ValidationResult(false, "Значение не может быть пустым");

            if (!IsUnique(input))
                return new ValidationResult(false, "Данный e-mail уже занят");

            if (input.Length < 5)
                return new ValidationResult(false, "E-mail должен состоять минимум из 5 символов");

            if (input.Length > 50)
                return new ValidationResult(false, "E-mail должен быть не более 50 символов");

            if (!CheckEmail(input))
                return new ValidationResult(false, "Некорректный e-mail");

            return ValidationResult.ValidResult;
        }
    }
}

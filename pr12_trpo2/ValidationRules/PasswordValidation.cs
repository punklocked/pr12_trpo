using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_trpo2.ValidationRules
{
    public class PasswordValidation : ValidationRule
    {
        public static bool CheckLower(string input)
        {
            bool result = false;

            foreach (char c in input)
            {
                if (char.IsLower(c))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static bool CheckUpper(string input)
        {
            bool result = false;

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static bool CheckChars(string input)
        {
            bool result = false;

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static bool CheckNum(string input)
        {
            bool result = false;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public static bool CheckPass(string input)
        {
            if (!CheckLower(input)) return false;
            if (!CheckUpper(input)) return false;
            if (!CheckChars(input)) return false;
            if (!CheckNum(input)) return false;

            return true;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();

            if (input == string.Empty)
                return new ValidationResult(false, "Значение не может быть пустым");

            if (!CheckPass(input))
                return new ValidationResult(false, "Пароль должен иметь символы, цифры, верхний и нижний регистр");

            if (input.Length < 8)
                return new ValidationResult(false, "Пароль должен быть не менее 8 символов");

            if (input.Length > 50)
                return new ValidationResult(false, "Пароль должен быть не более 50 символов");

            return ValidationResult.ValidResult;
        }
    }
}

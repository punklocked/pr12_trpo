using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_trpo2.ValidationRules
{
    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();

            if (input == string.Empty)
                return new ValidationResult(false, "Значение не может быть пустым");

            if (input.Length < 2)
                return new ValidationResult(false, "Имя должно состоять минимум из 2 символов");

            if (input.Length > 50)
                return new ValidationResult(false, "Имя должно быть не более 50 символов");

            return ValidationResult.ValidResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_trpo2.ValidationRules
{
    public class CreatedAtValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = Convert.ToDateTime(value);

            if (value == null)
                return new ValidationResult(false, "Значение не может быть пустым");

            if (input < DateTime.Today)
                return new ValidationResult(false, "Дата не может быть раньше текущей даты");

            return ValidationResult.ValidResult;
        }
    }
}

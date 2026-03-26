using pr12_trpo2.Data;
using pr12_trpo2.Service;

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
        public int CurrentUserId { get; set; }
        
        public static bool IsUnique(string input, int currentUserId)
        {

            foreach (Users user in UserService.Users)
            {
                //if (currentUserId != 0 && user.Id == currentUserId)
                
                
                if (user.Login.ToLower() == input.ToLower())
                    return false;
            }
            return true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();

            if (input == string.Empty)
                return new ValidationResult(false, "Значение не может быть пустым");

            //if()

            if (!IsUnique(input, CurrentUserId))
                return new ValidationResult(false, "Данный логин уже занят");

            if (input.Length < 5)
                return new ValidationResult(false, "Логин должен состоять минимум из 5 символов");

            if (input.Length > 50)
                return new ValidationResult(false, "Логин должен быть не более 50 символов");

            return ValidationResult.ValidResult;
        }
    }
}

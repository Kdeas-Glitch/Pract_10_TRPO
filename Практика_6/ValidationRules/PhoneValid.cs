using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Практика_7.ValidationRules
{
    class PhoneValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Length != 10)
            {
                return new ValidationResult(false, "Должно быть 10 цифр");
            }
            for (int i = 0; i < input.Count(); i++)
            {
                if (!Char.IsDigit(input[i]))
                {
                    return new ValidationResult(false, "Должны присутвовать только Цифры");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}

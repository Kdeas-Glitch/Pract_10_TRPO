using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Практика_7.ValidationRules
{
    class OnlyLettersValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            for(int i = 0; i < input.Count(); i++)
            {
                if (!Char.IsLetter(input[i]))
                {
                    return new ValidationResult(false, "Должны присутвовать только буквы");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}

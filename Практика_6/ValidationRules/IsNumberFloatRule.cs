using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Практика_7.ValidationRules
{
    class IsNumberFloatRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (!float.TryParse(input, out float floatValue))
            {
                return new ValidationResult(false, "Необходимо ввести число");
            }
            return ValidationResult.ValidResult;
        }
    }
}

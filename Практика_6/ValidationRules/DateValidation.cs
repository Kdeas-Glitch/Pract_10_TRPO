using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Практика_7.ValidationRules
{
    class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Count()!=10)
            {
                return new ValidationResult(false, "Необходимо ввести Полную дату ДД.ММ.ГГГГ");
            }
            if (!DateTime.TryParse(input, out DateTime dateTime))
            {
                return new ValidationResult(false, "Необходимо ввести Дату");
            }
            if (Convert.ToDateTime(input)>DateTime.Now)
            {
                return new ValidationResult(false, "Необходимо ввести реальную Дату");
            }
            if (Convert.ToDateTime(input).Year < 1926)
            {
                return new ValidationResult(false, "Необходимо ввести реальную Дату");
            }
            return ValidationResult.ValidResult;
        }
    }
}

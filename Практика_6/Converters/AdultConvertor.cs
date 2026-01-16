using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Практика_7.Converters
{
    class AdultConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return String.Empty;
            if (value is double s)
            {
                if (s >= 18)
                {
                    return "Совершеннолетний";
                }
                return "Несовершеннолетний";
            }
            return String.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            return null;
        }
    }
}

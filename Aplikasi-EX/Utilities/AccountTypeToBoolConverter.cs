using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace Aplikasi_EX.Utilities
{
    public class AccountTypeToBoolConverter : IValueConverter
    {
        // Convert from AccountType (string) to IsChecked (bool)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            return value.ToString() == parameter.ToString(); // Compare the value with the parameter
        }

        // Convert back from IsChecked (bool) to AccountType (string)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter.ToString() : null; // Return the corresponding account type
        }
    }

}

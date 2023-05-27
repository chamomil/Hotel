using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ValueConverters
{
    class SizeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 1)
            {
                return "One-bed";
            }
            else if ((int)value == 2)
            {
                return "Two-bed";
            }
            else if ((int)value == 3)
            {
                return "Three-bed";
            }
            else
            {
                return ">6 people";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

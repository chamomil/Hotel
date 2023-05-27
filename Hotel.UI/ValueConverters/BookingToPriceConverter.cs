using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ValueConverters
{
    class BookingToPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }
            return GetData((BookingData)value);
        }

        public int GetData(BookingData data)
        {
            return data.Room.Size * data.Room.Rank * (data.DateOfLeaving - data.DateOfEntry).Days * 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

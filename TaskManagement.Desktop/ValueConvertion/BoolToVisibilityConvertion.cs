using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TaskManagement.Desktop.ValueConvertion
{
    internal class BoolToVisibilityConvertion : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && targetType == typeof(bool))
            {
                return boolValue == true? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Visible; // Todo: Сюда не должен попасть, по идее
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibilityValue && targetType == typeof(Visibility))
            {
                return visibilityValue == Visibility.Visible ? true : false;
            }
            return false; // Todo: Сюда не должен попасть, по идее
        }
    }
}

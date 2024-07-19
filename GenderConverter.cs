using Avalonia.Data.Converters;
using ClientApp.MVVM.Models;
using System;
using System.Globalization;

namespace ClientApp
{
    public class GenderConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int gender)
            {
                return (GenderType)gender == GenderType.Man ? "Муж." : "Жен.";
            }
            return "неизвестно";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}

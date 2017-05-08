using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Reactor.Ticker.Wpf.General.Converters
{
    public class InvertedBooleanToVisibilityConverter : IValueConverter
    {
        private readonly BooleanToVisibilityConverter _innerConverter;

        public InvertedBooleanToVisibilityConverter()
        {
            _innerConverter = new BooleanToVisibilityConverter();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return _innerConverter.Convert(true, targetType, parameter, culture);

            var boolValue = (bool) value;
            return _innerConverter.Convert(!boolValue, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

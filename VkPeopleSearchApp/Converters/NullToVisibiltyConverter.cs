﻿using System;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VkPeopleSearchApp.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            var invert = false;
            if (parameter != null)
            {
                Boolean.TryParse(parameter.ToString(), out invert);
            }
            if (value == null) return invert ? Visibility.Visible : Visibility.Collapsed;

            if (value is string)
                if (!invert)
                    return string.IsNullOrWhiteSpace((string)value) ? Visibility.Collapsed : Visibility.Visible;
                else
                    return string.IsNullOrWhiteSpace((string)value) ? Visibility.Visible : Visibility.Collapsed;

            if (value is IList)
            {
                bool empty = ((IList)value).Count == 0;
                if (invert)
                    empty = !empty;
                if (empty)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }

            if (value is TimeSpan)
            {
                if (!invert)
                    return (TimeSpan)value != TimeSpan.Zero ? Visibility.Visible : Visibility.Collapsed;
                else
                    return (TimeSpan)value == TimeSpan.Zero ? Visibility.Collapsed : Visibility.Visible;
            }

            decimal number;
            if (Decimal.TryParse(value.ToString(), out number))
            {
                if (!invert)
                    return number > 0 ? Visibility.Visible : Visibility.Collapsed;
                else
                    return number > 0 ? Visibility.Collapsed : Visibility.Visible;

            }

            return invert ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}

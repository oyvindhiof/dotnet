using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace ComicsUniverse.Helpers
{
    public class StringLengthInvisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string itemVal = value as string;
            return string.IsNullOrWhiteSpace(itemVal) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

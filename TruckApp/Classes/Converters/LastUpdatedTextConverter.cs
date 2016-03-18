using System;
using Windows.UI.Xaml.Data;

namespace TruckersMPApp.Classes.Converters
{
    class LastUpdatedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return String.Format("Last updated: {0}", ((DateTime)value).ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using Windows.UI.Xaml.Data;

namespace TruckersMPApp.Classes.Converters
{
    class FilteringTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return String.Format("Filtering active: {0} servers", value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

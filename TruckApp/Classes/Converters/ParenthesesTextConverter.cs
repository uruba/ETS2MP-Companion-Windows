using System;
using Windows.UI.Xaml.Data;

namespace TruckersMPApp.Classes.Converters
{
    class ParenthesesTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return String.Format("({0})", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

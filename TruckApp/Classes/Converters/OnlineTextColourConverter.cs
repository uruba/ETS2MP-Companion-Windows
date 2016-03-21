using System;
using Windows.UI.Xaml.Data;

namespace TruckersMPApp.Classes.Converters
{
    class OnlineTextColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return App.Current.Resources[(bool)value ? "SystemControlHighlightAccentBrush" : "SystemControlForegroundBaseHighBrush"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

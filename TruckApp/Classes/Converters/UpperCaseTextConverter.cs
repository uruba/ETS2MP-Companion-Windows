﻿using System;
using Windows.UI.Xaml.Data;

namespace TruckersMPApp.Classes.Converters
{
    class UpperCaseTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((string) value).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

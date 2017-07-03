using System;
using System.Globalization;

using Xamarin.Forms;

namespace FavMovies.Clients.UI
{
    /// <summary>
    /// Is favorite text converter.
    /// </summary>
    class IsFavoriteTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            
            return (bool)value ? "Unfavorite" : "Favorite";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Is favorite detail text converter.
    /// </summary>
    class IsFavoriteDetailTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Save As Favorite";

            bool val = (bool)value ;
            return val ? "Remove from Favorites" : "Save As Favorite";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


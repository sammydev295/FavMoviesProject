using System;
using System.Globalization;
using System.Diagnostics;

using Xamarin.Forms;

using FavMovies.DataObjects;

namespace FavMovies.Clients.UI
{
    class MovieDateDisplayConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var movie = value as MovieBO;
                if(movie == null)
                    return string.Empty;
                
                return movie.ReleaseDate;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to convert: " + ex);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


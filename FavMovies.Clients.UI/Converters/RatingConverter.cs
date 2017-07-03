using System;
using System.Globalization;

using Xamarin.Forms;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;

namespace FavMovies.Clients.UI
{
    /// <summary>
    /// Rating converter for display text
    /// </summary>
    class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal rating = (decimal)value;
            int starNumber = (int)parameter;
            switch (starNumber)
            {
                case 1:
                    return (rating >= 0 && rating < 1);

                case 2:
                    return (rating >= 1 && rating < 2);

                case 3:
                    return (rating >= 2 && rating < 3);

                case 4:
                    return (rating >= 3 && rating < 4);

                case 5:
                    return (rating >= 4 && rating < 5);

                default:
                    return false;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Determins if the rating section should be visible
    /// </summary>
    class RatingVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            #if DEBUG || ENABLE_TEST_CLOUD
            return true;
            #endif

            var movie = value as MovieBO;
            if (movie == null)
                return false;

            if (movie.ReleaseDate == null)
                return false;

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

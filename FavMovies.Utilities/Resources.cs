using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FavMovies.Utilities
{
    public class Resources
    {
        public static ImageSource GetImageFromUri(string source)
        {
            return ImageSource.FromUri(new Uri(source));
        }
    }
}

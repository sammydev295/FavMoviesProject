using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavMovies.Clients.Portable.Interfaces
{
    public interface ILocalize
    {
        System.Globalization.CultureInfo GetCurrentCultureInfo();
        string GetCurrentLocal();
        void SetLocale();
    }
}

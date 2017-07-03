using System.Threading;
using Xamarin.Forms;

using FavMovies.Droid.Injected;
using FavMovies.Clients.Portable.Interfaces;

[assembly: Dependency(typeof(Localize))]
namespace FavMovies.Droid.Injected
{
    public class Localize : ILocalize
    {
        public void SetLocale()
        {
            var ci = GetCurrentCultureInfo();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public string GetCurrentLocal()
        {
            return "en-US";
        }

        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}
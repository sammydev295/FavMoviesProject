using System;
using System.Globalization;
using System.Threading;

using Xamarin.Forms;
using Foundation;

using FavMovies.Clients.Portable.Interfaces;

[assembly: Dependency(typeof(FavMovies.iOS.Injected.Localize))]
namespace FavMovies.iOS.Injected
{
    class Localize : ILocalize
    {
        public void SetLocale()
        {
            var ci = new CultureInfo(GetCurrentLocal());
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public string GetCurrentLocal()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;    // en_FR
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;      // en
            var netLocale = iosLocaleAuto.Replace("_", "-");
            var netLanguage = iosLanguageAuto.Replace("_", "-");

#if DEBUG
            Console.WriteLine("nslocaleid: {0}", iosLocaleAuto);
            Console.WriteLine("nslanguage: {0}", iosLanguageAuto);
            Console.WriteLine("ios: {0} {1}", iosLanguageAuto, iosLocaleAuto);
            Console.WriteLine("net: {0} {1}", netLanguage, netLocale);

            Console.WriteLine("thread:   {0}", Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui: {0}", Thread.CurrentThread.CurrentUICulture);

#endif

            const string defaultCulture = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
                try
                {
                    var ci = CultureInfo.CreateSpecificCulture(netLanguage);
                    netLanguage = ci.Name;
                }
                catch
                {
                    netLanguage = defaultCulture;
                }
            }
            else
            {
                netLanguage = defaultCulture;
            }

#if DEBUG
            Console.WriteLine(netLanguage);
#endif

            return netLanguage;
        }

       
        CultureInfo ILocalize.GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var prefLanguageOnly = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                prefLanguageOnly = pref.Substring(0, 2);

                if (prefLanguageOnly == "pt")
                {
                    if (pref == "pt")
                        pref = "pt-BR"; // Brazilian
                    else
                        pref = "pt-PT"; // Portuguese
                }

                netLanguage = pref.Replace("_", "-");
            }

            CultureInfo cultureInfo = null;
            try
            {
                cultureInfo = new CultureInfo(netLanguage);
            }
            catch
            {
                // Fallback to first two characters, e.g. "en"
                cultureInfo = new CultureInfo(prefLanguageOnly);
            }

            return cultureInfo;
        }
    }
}
using System;
using System.Collections;
using System.Diagnostics;

using FavMovies.Utilities.Interface;
using FavMovies.Clients.Portable.Injections;

[assembly: Xamarin.Forms.Dependency(typeof(Logger))]
namespace FavMovies.Clients.Portable.Injections
{
    public class Logger : ILogger
    {
        public void Report(Exception exception = null, Severity warningLevel = Severity.Warning)
        {
            Debug.WriteLine("FavMovies Logger: Report: " + exception);
        }

        public void Report(Exception exception, IDictionary extraData, Severity warningLevel = Severity.Warning)
        {
            Debug.WriteLine("FavMovies Logger: Report: " + exception);
        }

        public void Report(Exception exception, string key, string value, Severity warningLevel = Severity.Warning)
        {
            Debug.WriteLine("FavMovies Logger: Report: " + exception + " key: " + key + " value: " + value);
        }

        public void Track(string trackIdentifier)
        {
            Debug.WriteLine("v Logger: Track: " + trackIdentifier);
        }

        public void Track(string trackIdentifier, string key, string value)
        {
            Debug.WriteLine("FavMovies Logger: Track: " + trackIdentifier + " key: " + key + " value: " + value);
        }

        public void TrackPage(string page, string id = null)
        {
            Debug.WriteLine("FavMovies Logger: TrackPage: " + page.ToString() + " Id: " + id ?? string.Empty);
        }
    }
}

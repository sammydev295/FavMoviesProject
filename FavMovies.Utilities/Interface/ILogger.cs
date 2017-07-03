using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavMovies.Utilities.Interface
{
    public interface ILogger
    {
        void TrackPage(string page, string id = null);
        void Track(string trackIdentifier);
        void Track(string trackIdentifier, string key, string value);
        void Report(Exception exception = null, Severity warningLevel = Severity.Warning);
        void Report(Exception exception, IDictionary extraData, Severity warningLevel = Severity.Warning);
        void Report(Exception exception, string key, string value, Severity warningLevel = Severity.Warning);
    }

    public enum Severity
    {
        /// <summary>
        /// Warning Severity
        /// </summary>
        Warning,
        /// <summary>
        /// Error Severity, you are not expected to call this from client side code unless you have disabled unhandled exception handling.
        /// </summary>
        Error,
        /// <summary>
        /// Critical Severity
        /// </summary>
        Critical
    }
}

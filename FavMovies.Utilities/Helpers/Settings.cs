using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Plugin.Settings;
using Plugin.Settings.Abstractions;

using FavMovies.Utilities.Interface;

namespace FavMovies.Clients.Portable
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings // : INotifyPropertyChanged
    {
        #region Singleton

        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #endregion

        #region Favorites Related

        public static bool IsFavorite(string id)
        {
            bool ret = false;
            try
            {
                ret = AppSettings.GetValueOrDefault<Boolean>("fav_" + id, false);
            }
            catch (Exception ex)
            {
                DependencyService.Get<ILogger>().Report(ex, Severity.Critical);
            }

            return ret;
        }

        /// <summary>
        /// Toggles the saved favorites setting, creating the setting if needed
        /// </summary>
        /// <param name="id">ID for which to toggle favorite status</param>
        public static void ToggleFavorite(string id)
        {
            try
            {
                AppSettings.AddOrUpdateValue<Boolean>("fav_" + id, !IsFavorite(id));
            }
            catch (Exception ex)
            {
                DependencyService.Get<ILogger>().Report(ex, Severity.Critical);
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation (commented out)

        //public event PropertyChangedEventHandler PropertyChanged;
        //void OnPropertyChanged([CallerMemberName]string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion
    }
}
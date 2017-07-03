using System;

using ToastIOS;
using Xamarin.Forms;

using FavMovies.Clients.Portable.Interfaces;

[assembly: Dependency(typeof(FavMovies.iOS.Injected.Toaster))]
namespace FavMovies.iOS.Injected
{
    public class Toaster : IToast
    {
        /// <summary>
        /// Post a standard duration toast
        /// </summary>
        /// <param name="message">Toast message</param>
        public void SendToast(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Toast.MakeText(message, Toast.LENGTH_LONG).SetCornerRadius(0).Show();
            });
        }
    }
}
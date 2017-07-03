using System;

using Android.Content;
using Android.Widget;

using Xamarin.Forms;

using FavMovies.Droid;
using FavMovies.Clients.Portable.Interfaces;

[assembly: Dependency(typeof(FavMovies.Droid.Toaster))]
namespace FavMovies.Droid
{
    public class Toaster : IToast
    {
        /// <summary>
        /// Make a standard duration toast
        /// </summary>
        /// <param name="message">Toast message</param>
        public void SendToast(string message)
        {
            var context = Android.App.Application.Context;
            Device.BeginInvokeOnMainThread(() =>
            {
                Toast.MakeText(context, message, ToastLength.Long).Show();
            });
        }
    }
}
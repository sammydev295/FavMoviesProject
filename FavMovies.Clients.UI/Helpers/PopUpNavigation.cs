using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavMovies.Clients.Portable.Locator;
using FavMovies.Clients.UI.Helpers;
using FavMovies.Clients.UI.Views;
using FavMovies.Utilities.Interface;
using FavMovies.Views;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

[assembly: Dependency(typeof(PopUpNavigation))]

namespace FavMovies.Clients.UI.Helpers
{
    public class PopUpNavigation : IPopUpNavigation
    {
        public PopupPage Page(string pagename)
        {
            return Page(pagename, null);
        }

        public PopupPage Page(string pagename, object value )
        {
            switch (pagename)
            {
                case ViewModelLocator.MoviesDetailKey:
                    return value == null ? new MoviesDetail() : new MoviesDetail(value);
                    break;
                case ViewModelLocator.VideoPlayerKey:
                    return value == null ? new VideoPlayer() : new VideoPlayer(value);
                    break;
            }

            return null;
        }
    }
}

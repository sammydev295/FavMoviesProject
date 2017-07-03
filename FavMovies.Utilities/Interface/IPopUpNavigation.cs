using System;
using Rg.Plugins.Popup.Pages;

namespace FavMovies.Utilities.Interface

{
    public interface IPopUpNavigation
    {
        PopupPage Page(string pagename);
        PopupPage Page(string pagename, object value);
    }
}

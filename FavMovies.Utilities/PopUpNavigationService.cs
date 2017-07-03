using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace FavMovies.Utilities
{
    public class PopUpNavigationService
    {
        public static INavigation Navigation;
        public static void PushPopUpAsync(Rg.Plugins.Popup.Pages.PopupPage page)
        {
            Navigation.PushPopupAsync(page);
        }
        public static void PopPopUpAsync()
        {
            Navigation.PopPopupAsync();
        }
        public static void PopAllPopupAsync()
        {
            Navigation.PopAllPopupAsync();
        }

    }
}

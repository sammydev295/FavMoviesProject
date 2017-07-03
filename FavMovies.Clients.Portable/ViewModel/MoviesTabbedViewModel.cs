using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Views;

namespace FavMovies.Clients.Portable.ViewModel
{
    public class MoviesTabbedViewModel : BaseViewModel
    {
        #region CTOR

        public MoviesTabbedViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion
    }
}

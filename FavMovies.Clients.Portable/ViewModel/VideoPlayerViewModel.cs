using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Xamarin.Forms;

using FavMovies.Utilities;

namespace FavMovies.Clients.Portable.ViewModel
{
    public class VideoPlayerViewModel : BaseViewModel
    {
        #region CTOR

        public VideoPlayerViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion

        #region Properties

        private string _source;
        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Relay Commands

        public RelayCommand CloseCommand => new RelayCommand(Close_OnClick);
        private void Close_OnClick()
        {
            PopUpNavigationService.PopPopUpAsync();
        }

        #endregion
    }
}

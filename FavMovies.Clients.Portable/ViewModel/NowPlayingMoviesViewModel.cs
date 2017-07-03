using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Xamarin.Forms;

using FavMovies.Clients.Portable.Locator;
using FavMovies.DataStore.Abstractions;
using FavMovies.DataObjects;
using FavMovies.Utilities;
using FavMovies.Utilities.Interface;

namespace FavMovies.Clients.Portable.ViewModel
{
    public class NowPlayingMoviesViewModel : BaseViewModel
    {
        #region CTOR

        public NowPlayingMoviesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion

        #region Relay Commands
        public RelayCommand<MovieBO> NowPlayingCommand => new RelayCommand<MovieBO>(NowPlaying_Onclick);
        public RelayCommand ForceRefreshCommand => new RelayCommand(ForceRefresh_Onclick);

        #endregion

        #region Observable Properties

        public int NowPlayingPageNumber { get; set; }

        #region ShowNowPlaying

        private bool _showNowPlaying = false;
        public bool ShowNowPlaying
        {
            get { return _showNowPlaying; }
            set
            {
                _showNowPlaying = value;
                RaisePropertyChanged(() => ShowNowPlaying);
            }
        }

        #endregion

        #region Show NowPlayingIndicator

        private bool _showNowPlayingIndicator = true;
        public bool ShowNowPlayingIndicator
        {
            get { return _showNowPlayingIndicator; }
            set
            {
                _showNowPlayingIndicator = value;
                RaisePropertyChanged(() => ShowNowPlayingIndicator);
            }
        }

        #endregion

        #region Show ShowNowPlayingBottomIndicator

        private bool _showNowPlayingBottomIndicator = false;
        public bool ShowNowPlayingBottomIndicator
        {
            get { return _showNowPlayingBottomIndicator; }
            set
            {
                _showNowPlayingBottomIndicator = value;
                RaisePropertyChanged(() => ShowNowPlayingBottomIndicator);
            }
        }

        #endregion

        #region Now Playing

        private ObservableCollection<MovieBO> _nowPlayingList = new ObservableCollection<MovieBO>();
        public ObservableCollection<MovieBO> NowPlayingList
        {
            get { return _nowPlayingList; }
            set
            {
                _nowPlayingList = value;
                RaisePropertyChanged(() => NowPlayingList);
            }
        }

        private MovieBO _nowPlayingMovie;
        public MovieBO NowPlayingMovie
        {
            get { return _nowPlayingMovie; }
            set
            {
                _nowPlayingMovie = value;
                RaisePropertyChanged(() => NowPlayingMovie);
            }
        }
        #endregion

        #region IsBusy

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        #endregion

        #endregion

        #region Events

        private void ForceRefresh_Onclick()
        {
            IsBusy = true;
            NowPlayingPageNumber = 0;
            Initialize();
            IsBusy = false;
        }
        private void NowPlaying_Onclick(MovieBO movie)
        {
            var page = DependencyService.Get<IPopUpNavigation>().Page(ViewModelLocator.MoviesDetailKey, movie);
            PopUpNavigationService.PushPopUpAsync(page);
        }

        #endregion

        #region Data Acquisition

        public async void Initialize()
        {
            var store = DependencyService.Get<IMovieStore>();

            var nowPlayingMovies = await store.GetNowPlayingMovies(NowPlayingPageNumber + 1);
            NowPlayingPageNumber++;
            NowPlayingList = new ObservableCollection<MovieBO>(nowPlayingMovies);
            ShowNowPlaying = true; ShowNowPlayingIndicator = false;
        }

        public async void UpdateNowPlayingList()
        {
            ShowNowPlayingBottomIndicator = true;
            var store = DependencyService.Get<IMovieStore>();
            var nowPlayingList = await store.GetNowPlayingMovies(NowPlayingPageNumber + 1);
            ShowNowPlayingBottomIndicator = false;
            if (nowPlayingList == null)
                return;
            foreach (var item in nowPlayingList)
            {
                NowPlayingList.Add(item);
            }
            NowPlayingPageNumber++;
        }

        #endregion
    }
}

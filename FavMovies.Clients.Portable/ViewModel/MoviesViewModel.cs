using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Command;

using Xamarin.Forms;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;
using FavMovies.Utilities;
using FavMovies.Utilities.Interface;
using FavMovies.Clients.Portable.Locator;

namespace FavMovies.Clients.Portable.ViewModel
{
    public class MoviesViewModel : BaseViewModel
    {
        #region CTOR

        public MoviesViewModel(INavigationService navigationService) : base(navigationService)
        {
            Initialize();
        }

        #endregion

        #region Relay Commands

        public RelayCommand TopRatedCommand => new RelayCommand(TopRated_Onclick);
        public RelayCommand PopularCommand => new RelayCommand(Popular_Onclick);
        public RelayCommand NowPlayingCommand => new RelayCommand(NowPlaying_Onclick);
        public RelayCommand ForceRefreshCommand => new RelayCommand(ForceRefresh_Onclick);

        #endregion

        #region Other Properties

        public int TopRatedPageNumber { get; set; }
        public int PopularPageNumber { get; set; }
        public int NowPlayingPageNumber { get; set; }

        #endregion

        #region Observable Properties

        #region Top Rated

        private ObservableCollection<MovieBO> _topRatedList = new ObservableCollection<MovieBO>();
        public ObservableCollection<MovieBO> TopRatedList
        {
            get { return _topRatedList; }
            set
            {
                _topRatedList = value;
                RaisePropertyChanged(() => TopRatedList);
            }
        }

        private MovieBO _topRatedMovie;
        public MovieBO TopRatedMovie
        {
            get { return _topRatedMovie; }
            set
            {
                _topRatedMovie = value;
                RaisePropertyChanged(() => TopRatedMovie);
            }
        }


        #endregion

        #region Popular

        private ObservableCollection<MovieBO> _popularList = new ObservableCollection<MovieBO>();
        public ObservableCollection<MovieBO> PopularList
        {
            get { return _popularList; }
            set
            {
                _popularList = value;
                RaisePropertyChanged(() => PopularList);
            }
        }

        private MovieBO _popularRatedMovie;
        public MovieBO PopularMovie
        {
            get { return _popularRatedMovie; }
            set
            {
                _popularRatedMovie = value;
                RaisePropertyChanged(() => PopularMovie);
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

        #region Boolean Properties

        #region ShowTopRated

        private bool _showTopRated = false;
        public bool ShowTopRated
        {
            get { return _showTopRated; }
            set
            {
                _showTopRated = value;
                RaisePropertyChanged(() => ShowTopRated);
            }
        }

        #endregion

        #region ShowTopRatedIndicator

        private bool _showTopRatedIndicator = true;
        public bool ShowTopRatedIndicator
        {
            get { return _showTopRatedIndicator; }
            set
            {
                _showTopRatedIndicator = value;
                RaisePropertyChanged(() => ShowTopRatedIndicator);
            }
        }

        #endregion

        #region ShowTopRatedBottomIndicator

        private bool _showTopRatedBottomIndicator;
        public bool ShowTopRatedBottomIndicator
        {
            get { return _showTopRatedBottomIndicator; }
            set
            {
                _showTopRatedBottomIndicator = value;
                RaisePropertyChanged(() => ShowTopRatedBottomIndicator);
            }
        }

        #endregion

        #region ShowPopular

        private bool _showPopular = false;
        public bool ShowPopular
        {
            get { return _showPopular; }
            set
            {
                _showPopular = value;
                RaisePropertyChanged(() => ShowPopular);
            }
        }

        #endregion

        #region ShowPopularIndicator

        private bool _showPopularIndicator = true;
        public bool ShowPopularIndicator
        {
            get { return _showPopularIndicator; }
            set
            {
                _showPopularIndicator = value;
                RaisePropertyChanged(() => ShowPopularIndicator);
            }
        }

        #endregion

        #region ShowPopularBottomIndicator

        private bool _showPopularBottomIndicator = false;
        public bool ShowPopularBottomIndicator
        {
            get { return _showPopularBottomIndicator; }
            set
            {
                _showPopularBottomIndicator = value;
                RaisePropertyChanged(() => ShowPopularBottomIndicator);
            }
        }

        #endregion

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

        #endregion

        #region Events

        private void ForceRefresh_Onclick()
        {
            IsBusy = true;
            PopularPageNumber = 0;
            TopRatedPageNumber = 0;
            NowPlayingPageNumber = 0;
            Initialize();
            IsBusy = false;
        }
        private void TopRated_Onclick()
        {
            var page = DependencyService.Get<IPopUpNavigation>().Page(ViewModelLocator.MoviesDetailKey, TopRatedMovie);
            PopUpNavigationService.PushPopUpAsync(page);
        }
        private void Popular_Onclick()
        {
            var page = DependencyService.Get<IPopUpNavigation>().Page(ViewModelLocator.MoviesDetailKey, PopularMovie);
            PopUpNavigationService.PushPopUpAsync(page);
        }
        private void NowPlaying_Onclick()
        {
            var page = DependencyService.Get<IPopUpNavigation>().Page(ViewModelLocator.MoviesDetailKey, NowPlayingMovie);
            PopUpNavigationService.PushPopUpAsync(page);
        }

        #endregion

        #region Data Acquisition

        private async void Initialize()
        {
            var store = DependencyService.Get<IMovieStore>();
            
            var nowTopRatedMovies = await store.GetTopRatedMovies(TopRatedPageNumber+1);
            TopRatedPageNumber++;
            TopRatedList = new ObservableCollection<MovieBO>(nowTopRatedMovies);
            ShowTopRated = true;
            ShowTopRatedIndicator = false;
            
            var nowPopularMovies = await store.GetPopularMovies(PopularPageNumber+1);
            PopularPageNumber++;
            PopularList = new ObservableCollection<MovieBO>(nowPopularMovies);
            ShowPopular = true;
            ShowPopularIndicator = false;

            var nowPlayingMovies = await store.GetNowPlayingMovies(NowPlayingPageNumber+1);
            NowPlayingPageNumber++;
            NowPlayingList = new ObservableCollection<MovieBO>(nowPlayingMovies);
            ShowNowPlaying = true;
            ShowNowPlayingIndicator = false;
        }

        public async void UpdateTopRatedList()
        {
            var store = DependencyService.Get<IMovieStore>();

            ShowTopRatedBottomIndicator = true;
            var nowTopRatedMovies = await store.GetTopRatedMovies(TopRatedPageNumber + 1);
            ShowTopRatedBottomIndicator = false;
            if (nowTopRatedMovies == null)
                return;

            foreach (var item in nowTopRatedMovies)
            {
                TopRatedList.Add(item);
            }
            TopRatedPageNumber++;
        }

        public async void UpdatePopularList()
        {
            var store = DependencyService.Get<IMovieStore>();

            ShowPopularBottomIndicator = true;
            var nopularMovies = await store.GetPopularMovies(PopularPageNumber + 1);
            ShowPopularBottomIndicator = false;
            if (nopularMovies == null)
                return;

            foreach (var item in nopularMovies)
            {
                PopularList.Add(item);
            }
            PopularPageNumber++;
        }

        public async void UpdateNowPlayingList()
        {
            var store = DependencyService.Get<IMovieStore>();

            ShowNowPlayingBottomIndicator = true;
            var nowPlayingList = await store.GetNowPlayingMovies(NowPlayingPageNumber + 1);
            ShowNowPlayingBottomIndicator = false;
            if(nowPlayingList==null)
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

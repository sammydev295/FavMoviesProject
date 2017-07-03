using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Xamarin.Forms;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;
using FavMovies.Clients.Portable.Locator;
using FavMovies.Utilities;
using FavMovies.Utilities.Interface;

namespace FavMovies.Clients.Portable.ViewModel
{
    public class PopularMoviesViewModel : BaseViewModel
    {
        #region CTOR

        public PopularMoviesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion

        #region Observable Properties

        public int PopularPageNumber { get; set; }

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

        #region Relay Commands

        private void ForceRefresh_Onclick()
        {
            IsBusy = true;
            PopularPageNumber = 0;
            Initialize();
            IsBusy = false;
        }

        public RelayCommand<MovieBO> PopularCommand => new RelayCommand<MovieBO>(Popular_Onclick);
        public RelayCommand ForceRefreshCommand => new RelayCommand(ForceRefresh_Onclick);

        #endregion

        #region Events

        private void Popular_Onclick(MovieBO movie)
        {
            var page = DependencyService.Get<IPopUpNavigation>().Page(ViewModelLocator.MoviesDetailKey, movie);
            PopUpNavigationService.PushPopUpAsync(page);
        }

        #endregion

        #region Data Acquisition

        public async void UpdatePopularList()
        {
            ShowPopularBottomIndicator = true;
            var store = DependencyService.Get<IMovieStore>();
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

        public async void Initialize()
        {
            var store = DependencyService.Get<IMovieStore>();
            var nowPopularMovies = await store.GetPopularMovies(PopularPageNumber + 1);
            PopularPageNumber++;
            PopularList = new ObservableCollection<MovieBO>(nowPopularMovies);
            ShowPopular = true; ShowPopularIndicator = false;
        } 

        #endregion
    }
}

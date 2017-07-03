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
    public class TopRatedMoviesViewModel : BaseViewModel
    {
        #region CTOR

        public TopRatedMoviesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion

        #region Observable Properties

        public int TopRatedPageNumber { get; set; }

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

        public RelayCommand<MovieBO> TopRatedCommand => new RelayCommand<MovieBO>(TopRated_Onclick);
        public RelayCommand ForceRefreshCommand => new RelayCommand(ForceRefresh_Onclick);
        
        #endregion

        #region Events

        private void ForceRefresh_Onclick()
        {
            IsBusy = true;
            TopRatedPageNumber = 0;
            Initialize();
            IsBusy = false;
        }
        private void TopRated_Onclick(MovieBO movie)
        {
            var page = DependencyService.Get<IPopUpNavigation>().Page(ViewModelLocator.MoviesDetailKey, movie);
            PopUpNavigationService.PushPopUpAsync(page);
        }

        #endregion

        #region Data Acquisition

        public async void Initialize()
        {
            var store = DependencyService.Get<IMovieStore>();

            var nowTopRatedMovies = await store.GetTopRatedMovies(TopRatedPageNumber + 1);
            TopRatedPageNumber++;
            TopRatedList = new ObservableCollection<MovieBO>(nowTopRatedMovies);
            ShowTopRated = true; ShowTopRatedIndicator = false;
        }

        public async void UpdateTopRatedList()
        {
            ShowTopRatedBottomIndicator = true;
            var store = DependencyService.Get<IMovieStore>();
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

        #endregion
    }
}

using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Command;

using Acr.UserDialogs;

using Xamarin.Forms;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;
using FavMovies.Clients.Portable.Locator;
using FavMovies.Utilities;
using FavMovies.Utilities.Interface;

namespace FavMovies.Clients.Portable.ViewModel
{
    public class MoviesDetailViewModel : BaseViewModel
    {
        #region CTOR

        public MoviesDetailViewModel(INavigationService navigationService) :  base(navigationService)
        {
        }

        #endregion

        #region Observable Properties

        #region Rating Bar

        #region RatingCount List
        private ObservableCollection<string> _ratingCountList = new ObservableCollection<string>();

        public ObservableCollection<string> RatingCountList
        {
            get { return _ratingCountList; }
            set
            {
                _ratingCountList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Menu Options

        private List<MovieVideoBO> _menuOptions;
        public List<MovieVideoBO> MenuOptions
        {
            get { return _menuOptions; }
            set
            {
                _menuOptions = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region SimilarMovies

        private ObservableCollection<MovieBO> _similarMovies = new ObservableCollection<MovieBO>();
        public ObservableCollection<MovieBO> SimilarMovies
        {
            get { return _similarMovies; }
            set
            {
                _similarMovies = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region FilmBO

        private MovieBO _film;
        public MovieBO Film
        {
            get { return _film; }
            set
            {
                _film = value;
                Initialize(_film);
                RaisePropertyChanged();
            }
        }

        #endregion

        #region PosterPath

        private string _posterPath;
        public string PosterPath
        {
            get { return _posterPath; }
            set
            {
                _posterPath = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Title

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region ReleaseDate

        private string _releaseDate;
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                _releaseDate = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Popularity

        private decimal _popularity = 0;
        public decimal Popularity
        {
            get { return _popularity; }
            set
            {
                _popularity = value;
                RaisePropertyChanged(() => Popularity);
            }
        }

        #endregion

        #region VoteAverage

        private decimal _voteAverage = 0;
        public decimal VoteAverage
        {
            get { return _voteAverage; }
            set
            {
                _voteAverage = value;
                RaisePropertyChanged(() => VoteAverage);
            }
        }

        #endregion

        #region Overview

        private string _overview;
        public string Overview
        {
            get { return _overview; }
            set
            {
                _overview = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Votes

        private int _votes = 0;
        public int Votes
        {
            get { return _votes; }
            set
            {
                _votes = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region IsFavorite

        private bool _isFavorite = false;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                _isFavorite = value;
                RaisePropertyChanged(() => IsFavorite);
            }
        }

        #endregion

        #endregion

        #region Relay Commands

        public RelayCommand CloseCommand => new RelayCommand(Close_OnClick);
        public RelayCommand PlayVideoCommand => new RelayCommand(PlayVideo_OnClick);
        public RelayCommand SaveToFavCommand => new RelayCommand(SaveToFav_OnClick);

        #endregion

        #region Events
     
        private void Close_OnClick()
        {
            PopUpNavigationService.PopPopUpAsync();
        }

        private async void PlayVideo_OnClick()
        {
            if (MenuOptions == null)
            {
                await UserDialogs.Instance.AlertAsync("Loading Video Details! Please wait!");
                return;
            }

            var options = MenuOptions.Select(s => s.Name).ToArray();
            var item = await UserDialogs.Instance.ActionSheetAsync("Select Video", "cancel", null, null, options);
            if(item== "cancel")
                return;

            MovieVideoBO movie = MenuOptions.FirstOrDefault(s => s.Name == item);

            var page = DependencyService.Get<IPopUpNavigation>().Page(ViewModelLocator.VideoPlayerKey, movie.Uri);
            PopUpNavigationService.PushPopUpAsync(page);
        }

        async private void SaveToFav_OnClick()
        {
            var favorites = DependencyService.Get<IFavoriteService>();
            IsFavorite = await favorites.ToggleFavorite(Film);
        }

        #endregion

        #region Data Acquisition

        public async void Initialize(MovieBO film)
        {
            Title = film.Title;
            ReleaseDate = film.ReleaseDate;

            Popularity = film.Popularity;
            Votes = film.VoteCount;

            Overview = film.Overview;
            PosterPath = film.PosterPath;

            VoteAverage = GetVoteAvg(film.VoteAverage);
            SetRating();

            var favorites =  DependencyService.Get<IFavoriteService>();
            IsFavorite = favorites.IsFavorite(film.Id.ToString());
            Toast.SendToast($"Toggled favorites for movie {film.Title} to {IsFavorite.ToString()}");

            var storeMovieVideo = DependencyService.Get<IMovieVideoStore>();
            MenuOptions = await storeMovieVideo.GetMovieVideos(Film.Id);

            var storeMovie = DependencyService.Get<IMovieStore>();
            var similar = await storeMovie.GetSimilarMovies(film.Id, 1);
            SimilarMovies = new ObservableCollection<MovieBO>(similar);
        }

        private decimal GetVoteAvg(decimal popularity)
        {
            if (popularity < 0)
            {
                return 0;
            }
            else if (popularity > 0 && popularity <= 2)
            {
                return 1;
            }
            else if (popularity > 2 && popularity <= 4)
            {
                return 2;
            }
            else if (popularity > 4 && popularity <= 6)
            {
                return 3;
            }
            else if (popularity > 6 && popularity <= 8)
            {
                return 4;
            }
            else if (popularity > 8 && popularity <= 10)
            {
                return 5;
            }
            return 5;
        }

        private void SetRating()
        {
            var list = new ObservableCollection<string>();
            int totalStars = 5;

            for (int i = 1; i <= totalStars; i++)
            {

                list.Add(i <= VoteAverage?"star_selected.png": "star_outline.png");
                RatingCountList = list;
            }

        }
        
        #endregion
    }
}

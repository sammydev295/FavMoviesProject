using System;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

using Xamarin.Forms;

using FavMovies.Utilities.Interface;
using FavMovies.Clients.Portable.Interfaces;
using FavMovies.DataStore.Abstractions;

namespace FavMovies.Clients.Portable.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        #region CTOR

        public BaseViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
        }

        #endregion

        #region Init

        public static void Init(bool mock = true)
        {
            if (mock)
            {
                DependencyService.Register<IStoreManager, DataStore.Mock.StoreManager>();
                DependencyService.Register<IMovieStore, DataStore.Mock.MovieStore>();
                DependencyService.Register<IMovieVideoStore, DataStore.Mock.MovieVideoStore>();
                DependencyService.Register<IFavoriteStore, DataStore.Mock.FavoriteStore>();
            }
            else
            {
                DependencyService.Register<IStoreManager, DataStore.Cloud.StoreManager>();
                DependencyService.Register<IMovieStore, DataStore.Cloud.MovieStore>();
                DependencyService.Register<IMovieVideoStore, DataStore.Cloud.MovieVideoStore>();
                DependencyService.Register<IFavoriteStore, DataStore.Cloud.FavoriteStore>();
            }

            DependencyService.Register<IFavoriteService, FavMovies.Clients.Portable.FavoriteService>();
            DependencyService.Register<MediaService, FavMovies.Clients.Portable.MediaService>();
        }

        #endregion

        #region Properties

        protected INavigationService Navigation { get; set; }

        protected static ILogger Logger { get; } = DependencyService.Get<ILogger>();

        protected static IStoreManager StoreManager { get; } = DependencyService.Get<IStoreManager>();

        protected static IFavoriteStore FavoriteStore { get; } = DependencyService.Get<IFavoriteStore>();

        protected static IMovieStore MovieStore { get; } = DependencyService.Get<IMovieStore>();

        protected static IToast Toast { get; } = DependencyService.Get<IToast>();

        protected static IFavoriteService Favorites { get; } = DependencyService.Get<IFavoriteService>();

        #endregion
    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;

namespace FavMovies.DataStore.Cloud
{
    public class StoreManager : HttpClientBase, IStoreManager
    {
        #region IStoreManager implementation

        #region InitializeAsync

        public async Task InitializeAsync()
        {
            ApiBase = @"http://api.themoviedb.org/";
            await Task.Delay(1);
        }

        #endregion 

        #region GetItemsAsync

        public async Task<T> GetItemsAsync<T>(string requestPath) where T : new()
        {
            return await base.HttpGetRequest<T>(requestPath);
        }

        #endregion 

        #region The Stores

        IMovieStore movieStore;
        public IMovieStore MovieStore => movieStore ?? (movieStore = DependencyService.Get<IMovieStore>());

        IMovieVideoStore movieVideoStore;
        public IMovieVideoStore MovieVideoStore => movieVideoStore ?? (movieVideoStore = DependencyService.Get<IMovieVideoStore>());

        IFavoriteStore favoriteStore;
        public IFavoriteStore FavoriteStore => favoriteStore ?? (favoriteStore = DependencyService.Get<IFavoriteStore>());

        #endregion

        #endregion
    }
}




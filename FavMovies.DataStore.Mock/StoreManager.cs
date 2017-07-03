using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using FavMovies.DataStore.Abstractions;

namespace FavMovies.DataStore.Mock
{
    public class StoreManager : IStoreManager
    {
        #region IStoreManager implementation

        #region InitializeAsync

        public Task InitializeAsync()
        {
            return Task.FromResult(true);
        }

        #endregion

        #region GetItemsAsync

        public async Task<T> GetItemsAsync<T>(string requestPath) where T : new()
        {
            var data = new T();
            return await Task.FromResult(data);
        }

        #endregion 

        #endregion

        #region The Stores

        IMovieStore movieStore;
        public IMovieStore MovieStore => movieStore ?? (movieStore = DependencyService.Get<IMovieStore>());

        IMovieVideoStore movieVideoStore;
        public IMovieVideoStore MovieVideoStore => movieVideoStore ?? (movieVideoStore = DependencyService.Get<IMovieVideoStore>());

        IFavoriteStore favoriteStore;
        public IFavoriteStore FavoriteStore => favoriteStore ?? (favoriteStore = DependencyService.Get<IFavoriteStore>());

        #endregion
    }
}


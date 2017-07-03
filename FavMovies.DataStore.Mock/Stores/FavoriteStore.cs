using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;

namespace FavMovies.DataStore.Mock
{
    public class FavoriteStore : BaseStore<Favorite>, IFavoriteStore
    {
        public async Task<bool> IsFavorite(string userId, string movieId, string favoriteType)
        {
            return await Task.FromResult(false);
        }

        public async Task<IList<Favorite>> GetFavorites(string userId, string favoriteType)
        {
            return await Task.FromResult(new List<Favorite>());
        }
    }
}


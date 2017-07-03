using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using FavMovies.DataObjects;

namespace FavMovies.DataStore.Abstractions
{
    public interface IFavoriteStore : IBaseStore<Favorite>
    {
        Task<bool> IsFavorite(string userId, string lockerId, string favoriteType);
        Task<IList<Favorite>> GetFavorites(string userId, string favoriteType);
    }
}


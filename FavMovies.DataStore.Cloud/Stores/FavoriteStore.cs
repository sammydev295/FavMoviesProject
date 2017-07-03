using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FavMovies.DataStore.Abstractions;
using FavMovies.DataObjects;

namespace FavMovies.DataStore.Cloud
{
    public class FavoriteStore : BaseStore<Favorite>, IFavoriteStore
    {
        public async  Task<bool> IsFavorite(string userId, string lockerId, string favoriteType)
        {
            await InitializeStore().ConfigureAwait (false);
            return true;
        }
        public async Task<IList<Favorite>> GetFavorites(string userId, string favoriteType)
        {
            await InitializeStore().ConfigureAwait(false);
            var items = new List<Favorite>();
            return items;
        }

        public override string Identifier => "Favorite";
    }
}


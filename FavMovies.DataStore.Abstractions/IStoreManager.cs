using System;
using System.Threading.Tasks;

namespace FavMovies.DataStore.Abstractions
{
    public interface IStoreManager
    {
        Task InitializeAsync();

        Task<T> GetItemsAsync<T>(string requestPath) where T : new();
    }
}


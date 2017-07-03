using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using FavMovies.DataObjects;

namespace FavMovies.DataStore.Abstractions
{
    public interface IBaseStore<T>
    {
        Task InitializeStore();
        Task<ICollection<T>> GetItemsAsync(string api, params object[] actions);
        Task<T> GetItemAsync(string id);
        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> RemoveAsync(T item);
        string Identifier { get; }

        string ImagesURI { get; set; }
    }
}


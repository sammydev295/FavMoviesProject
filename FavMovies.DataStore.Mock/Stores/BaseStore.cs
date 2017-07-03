using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FavMovies.DataStore.Abstractions;

namespace FavMovies.DataStore.Mock
{
    public class BaseStore<T> : IBaseStore<T>
    {
        public string ImagesURI { get; set; }

        #region IBaseStore implementation

        public virtual System.Threading.Tasks.Task InitializeStore()
        {
            throw new NotImplementedException();
        }
        public virtual Task<ICollection<T>> GetItemsAsync(string api, params object[] actions)
        {
            throw new NotImplementedException();
        }
        public virtual System.Threading.Tasks.Task<T> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
        public virtual System.Threading.Tasks.Task<bool> InsertAsync(T item)
        {
            throw new NotImplementedException();
        }
        public virtual System.Threading.Tasks.Task<bool> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
        public virtual System.Threading.Tasks.Task<bool> RemoveAsync(T item)
        {
            throw new NotImplementedException();
        }

        public virtual string Identifier => "store";

        #endregion
    }
}


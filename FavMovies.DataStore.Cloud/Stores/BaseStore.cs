using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FavMovies.DataStore.Abstractions;
using FavMovies.DataObjects;

namespace FavMovies.DataStore.Cloud
{
    public class BaseStore<T> : IBaseStore<T> where T : class, new()
    {
        #region Fields

        IStoreManager storeManager;

        #endregion

        #region Properties

        public string ImagesURI { get; set; }

        public virtual string Identifier => "Items";

        #endregion

        #region CTOR

        public BaseStore()
        {
            
        }

        #endregion

        #region IBaseStore implementation

        public async Task InitializeStore()
        {
            if (storeManager == null)
                storeManager = DependencyService.Get<IStoreManager>();

             await storeManager.InitializeAsync().ConfigureAwait(false);
        }

        public virtual async Task<ICollection<T>> GetItemsAsync(string api, params object[] actions)
        {
            string uri = String.Format(api, actions);

            await InitializeStore().ConfigureAwait (false);
            return await storeManager.GetItemsAsync<List<T>>(uri);
        }

        public virtual async Task<T> GetItemAsync(string id)
        {
            await InitializeStore().ConfigureAwait(false);
            
            return null;
        }

        public virtual async Task<bool> InsertAsync(T item)
        {
            return true;
        }

        public virtual async Task<bool> UpdateAsync(T item)
        {
            await InitializeStore().ConfigureAwait(false);
            return true;
        }

        public virtual async Task<bool> RemoveAsync(T item)
        {
            await InitializeStore().ConfigureAwait(false);
            return true;
        }

        #endregion
    }
}


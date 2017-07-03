using System;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using FormsToolkit;

using FavMovies.Utilities.Interface;
using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;

[assembly: Xamarin.Forms.Dependency(typeof(FavMovies.Clients.Portable.FavoriteService))]
namespace FavMovies.Clients.Portable
{
    public interface IFavoriteService
    {
        /// <summary>
        /// Is item saved in favorites or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsFavorite(string id);

        /// <summary>
        /// Toggle fav status of item
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<bool> ToggleFavorite(MovieBO movie);
    }

    public class FavoriteService : IFavoriteService
    {
        #region CTOR

        public FavoriteService()
        {
        }

        #endregion

        #region IsFavorite

        public bool IsFavorite(string id)
        {
            return Settings.IsFavorite(id);
        }

        #endregion

        #region ToggleFavorite

        public async Task<bool> ToggleFavorite(MovieBO movie)
        {
            var store = DependencyService.Get<IFavoriteStore>();
            movie.IsFavorite = !movie.IsFavorite;//switch first so UI updates :)
            if (!movie.IsFavorite)
            {
                DependencyService.Get<ILogger>().Track("FavoriteRemoved", "Title", movie.OriginalTitle);

                //var items = await store.GetItemsAsync();
                //foreach (var item in items.Where (s => s.Id == movie.Id)) 
                //{
                //    await store.RemoveAsync (item);
                //}
            }
            else
            {
                DependencyService.Get<ILogger>().Track("FavoriteAdded", "Title", movie.OriginalTitle);
                //await store.InsertAsync(new Favorite{ Id = movie.Id });
            }

            // Leverage settings plug-in wrapper
            Settings.ToggleFavorite(movie.Id.ToString());

            return movie.IsFavorite;
        }

        #endregion
    }
}


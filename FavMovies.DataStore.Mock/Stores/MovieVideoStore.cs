using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;

namespace FavMovies.DataStore.Mock
{
    public class MovieVideoStore : BaseStore<MovieVideoBO>, IMovieVideoStore
    {
        #region Properties

        ObservableCollection<MovieBO> movies;

        public override string Identifier => "MovieVideos";

        /// <summary>
        /// Mock data
        /// </summary>
        string[] images => new string[] {
                "wine-5884__340.jpg",
                "white-wine-1761771__340.jpg",
            };

        #endregion

        #region CTOR

        public MovieVideoStore()
        {
        }

        #endregion

        #region IMovieVideoStore implementation

        public Task<List<MovieVideoBO>> GetMovieVideos(int movieId)
        {
            return null;
        }

        #endregion
    }
}

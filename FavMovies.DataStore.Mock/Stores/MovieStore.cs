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
    public class MovieStore : BaseStore<MovieBO>, IMovieStore
    {
        #region Properties

        ObservableCollection<MovieBO> movies;

        public override string Identifier => "Movies";

        /// <summary>
        /// Mock data
        /// </summary>
        string[] images => new string[] {
                "wine-5884__340.jpg",
                "bottle-147690__340.png",
                "champagne-146885__340.png",
                "frogs-1650657__340.jpg",
                "bordeaux-150955__340.png",
                "frogs-1650658__340.jpg",
                "wine-bottle-1209934__340.jpg",
                "wine-1209022__340.jpg",
                "wine-1839024__340.jpg",
                "white-wine-1761771__340.jpg",
            };

        #endregion

        #region CTOR

        public MovieStore()
        {
        }

        #endregion

        #region IMovieStore implementation

        public async Task<List<MovieBO>> GetNowPlayingMovies(int pageNo)
        {
            var data = new List<MovieBO>();
            return await Task.FromResult(data);
        }

        public async Task<List<MovieBO>> GetTopRatedMovies(int pageNo)
        {
            var data = new List<MovieBO>();
            return await Task.FromResult(data);
        }

        public async Task<List<MovieBO>> GetPopularMovies(int pageNo)
        {
            var data = new List<MovieBO>();
            return await Task.FromResult(data);
        }

        public async Task<List<MovieBO>> GetSimilarMovies(int movieId, int pageNo)
        {
            var data = new List<MovieBO>();
            return await Task.FromResult(data);
        }

        #endregion
    }
}

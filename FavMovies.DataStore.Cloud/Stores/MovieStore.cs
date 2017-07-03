using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;

namespace FavMovies.DataStore.Cloud
{
    public class MovieStore : BaseStore<MovieBO>, IMovieStore
    {
        public override string Identifier => "Movies";

        #region Constants

        private const string ApiNowPlayingUri = "/3/movie/now_playing?api_key=ab41356b33d100ec61e6c098ecc92140&sort_by=popularity.des&page={0}";

        private const string ApiTopRatedUri = "/3/movie/top_rated?api_key=ab41356b33d100ec61e6c098ecc92140&sort_by=popularity.des&page={0}";

        private const string ApiPopularUri = "/3/movie/popular?api_key=ab41356b33d100ec61e6c098ecc92140&sort_by=popularity.des&page={0}";

        private const string ApiSimilarUri = "/3/movie/293660/similar?api_key=ab41356b33d100ec61e6c098ecc92140&movie_id={0}&page={1}";

        #endregion

        #region IMovieStore implementation

        public async Task<List<MovieBO>> GetNowPlayingMovies(int pageNo)
        {
            var data = await GetItemsAsync(ApiNowPlayingUri, pageNo);
            return data.ToList();
        }

        public async Task<List<MovieBO>> GetTopRatedMovies(int pageNo)
        {
            var data = await GetItemsAsync(ApiTopRatedUri, pageNo);
            return data.ToList();
        }

        public async Task<List<MovieBO>> GetPopularMovies(int pageNo)
        {
            var data = await GetItemsAsync(ApiPopularUri, pageNo);
            return data.ToList();
        }

        public async Task<List<MovieBO>> GetSimilarMovies(int movieId, int pageNo)
        {
            var data = await GetItemsAsync(ApiSimilarUri, movieId, pageNo);
            return data.ToList();
        }

        #endregion
    }
}

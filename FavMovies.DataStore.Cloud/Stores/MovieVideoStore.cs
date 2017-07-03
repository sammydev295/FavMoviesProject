using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FavMovies.DataObjects;
using FavMovies.DataStore.Abstractions;

namespace FavMovies.DataStore.Cloud
{
    public class MovieVideoStore : BaseStore<MovieVideoBO>, IMovieVideoStore
    {
        public override string Identifier => "MovieVideos";

        #region Constants

        private const string ApiVideosUri = "/3/movie/293660/videos?api_key=ab41356b33d100ec61e6c098ecc92140&movie_id={0}";

        #endregion

        #region IMovieVideoStore implementation

        public async Task<List<MovieVideoBO>> GetMovieVideos(int movieId)
        {
            var data = await GetItemsAsync(ApiVideosUri, movieId);
            return data.ToList();
        }

        #endregion
    }
}

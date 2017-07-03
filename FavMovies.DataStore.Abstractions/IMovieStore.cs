using System.Collections.Generic;
using System.Threading.Tasks;

using FavMovies.DataObjects;

namespace FavMovies.DataStore.Abstractions
{
    public interface IMovieStore: IBaseStore<MovieBO>
    {
        Task<List<MovieBO>> GetNowPlayingMovies(int pageNo);

        Task<List<MovieBO>> GetTopRatedMovies(int pageNo);

        Task<List<MovieBO>> GetPopularMovies(int pageNo);

        Task<List<MovieBO>> GetSimilarMovies(int movieId, int pageNo);
    }
}

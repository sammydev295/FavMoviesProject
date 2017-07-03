using System.Collections.Generic;
using System.Threading.Tasks;

using FavMovies.DataObjects;

namespace FavMovies.DataStore.Abstractions
{
    public interface IMovieVideoStore : IBaseStore<MovieVideoBO>
    {
        Task<List<MovieVideoBO>> GetMovieVideos(int movieId);
    }
}

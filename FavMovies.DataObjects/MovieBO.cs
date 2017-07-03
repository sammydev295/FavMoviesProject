using System.Collections.Generic;
using System.Collections.ObjectModel;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FavMovies.DataObjects
{
    public class MovieBO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
        [JsonProperty("video")]
        public bool Video { get; set; }
        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }
        [JsonProperty("popularity")]
        public decimal Popularity { get; set; }

        private string _posterPath;
        [JsonProperty("poster_path")]
        public string PosterPath {
            get { return _posterPath; }
            set { _posterPath = "https://image.tmdb.org/t/p/w185_and_h278_bestv2/"+value; }
        }
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("gene_ids")]
        public ICollection<Genre> Genres { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsFavorite { get; set; } = false;
    }
}

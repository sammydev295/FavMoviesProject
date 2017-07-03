using Newtonsoft.Json;

namespace FavMovies.DataObjects
{
    public class MovieVideoBO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        private string _uri;
        [JsonProperty("key")]
        public string Uri {
            get { return _uri; }
            set { _uri = "https://www.youtube.com/embed/" + value; }
        }
    }
}

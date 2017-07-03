using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FavMovies.DataStore.Cloud
{
    public class HttpClientBase
    {
        #region Constants & Statics

        private static JsonSerializerSettings Settings = new JsonSerializerSettings();

        private const int MaxRetryCount = 5;

        #endregion

        #region Properties

        protected string ApiBase { get; set; }

        #endregion

        #region GetServicePathUri

        protected Uri GetServicePathUri(string path)
        {
            return new Uri(new Uri(ApiBase), path);
        }

        #endregion

        #region HttpGetRequestInternal

        protected async Task<Tuple<bool, string>> HttpGetRequestInternal(String requestPath)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(GetServicePathUri(requestPath));
                string jsonString = String.Empty;
                try
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    return new Tuple<bool, string>(false, jsonString);
                   
                }
                catch(Exception ex)
                {
                    jsonString = ex.Message;
                }
                return new Tuple<bool, string>(false, jsonString);
            }
        }

        #endregion

        #region HttpGetRequest

        public async Task<T> HttpGetRequest<T>(String requestPath)
        {
            string jsonString = string.Empty;

            try
            {
                var data = await HttpGetRequestInternal(requestPath);
                for (int i = 0; i < MaxRetryCount && data.Item1 == false; i++)
                {
                    data = await HttpGetRequestInternal(requestPath);
                }
                jsonString =  data.Item2;
                var json = JObject.Parse(jsonString)["results"].ToString();

                return JsonConvert.DeserializeObject<T>(json, Settings);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in deserialization of: [{jsonString}]: {ex.Message}", ex);
            }
        }

        #endregion
    }
}

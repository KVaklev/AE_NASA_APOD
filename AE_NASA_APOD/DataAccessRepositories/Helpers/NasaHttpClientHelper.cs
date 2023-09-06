using DataAccessRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepositories.Helpers
{
    public class NasaHttpClientHelper : INasaHttpClientHelper
    {
        private static readonly HttpClient client = new HttpClient();

        private const string apiKey = "7AFWJXgBtX6aYUuLhuYuGnG68YceR7phkkNfrXBx";

        public async Task<HttpResponseMessage> GetAllAsteriodsResponse()
        {
            return await client.GetAsync($"https://api.nasa.gov/neo/rest/v1/neo/browse?api_key={apiKey}");
        }

        public async Task<HttpResponseMessage> GetPictureOfTheDay()
        {
            // TODO: change to the correct api url
            return await client.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}");

            
        }

    }
}

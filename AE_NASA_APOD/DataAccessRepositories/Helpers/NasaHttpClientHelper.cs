using DataAccessRepositories.Contracts;

namespace DataAccessRepositories.Helpers
{
    public class NasaHttpClientHelper : INasaHttpClientHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public const string apiKey = "7AFWJXgBtX6aYUuLhuYuGnG68YceR7phkkNfrXBx";

        public async Task<HttpResponseMessage> GetAllAsteriodsResponse()
        {
            return await client.GetAsync($"https://api.nasa.gov/neo/rest/v1/neo/browse?api_key={apiKey}");
        }

        public async Task<HttpResponseMessage> GetPictureOfTheDay()
        {
            return await client.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}");
        }        

        public async Task<HttpResponseMessage> GetAPODByDate(DateTime? date)
        {
            if (date.HasValue)
            {
                string formattedDate = date.Value.ToString("yyyy-MM-dd");
                                
                string apiUrl = $"https://api.nasa.gov/planetary/apod?date={formattedDate}&api_key={apiKey}";
                               
                return await client.GetAsync(apiUrl);
            }
            else
            {                
                return await GetPictureOfTheDay();
            }
        }
    }
}

using BusinessServices.Contracts;
using DataAccessModels.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace BusinessServices.Models
{
    public class NASAApiService : INASAApiService
    {
        private readonly HttpClient httpClient;

        public NASAApiService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://api.nasa.gov/planetary/apod");
        }

        public Task<APOD> GetAPODAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Asteroid>> GetAsteroidsAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
    //public class NASAService
    //{
    //    private readonly HttpClient _httpClient;
    //    private readonly string _apiKey;

    //    public NASAService(HttpClient httpClient, string apiKey)
    //    {
    //        _httpClient = httpClient;
    //        _apiKey = apiKey;
    //    }

    //    public async Task<IEnumerable<AsteroidApiModel>> GetAsteroidsAsync()
    //    {
    //        try
    //        {
    //            var response = await _httpClient.GetAsync($"https://api.nasa.gov/neo/rest/v1/neo/browse?api_key={_apiKey}");
    //            response.EnsureSuccessStatusCode();

    //            var asteroidApiData = await response.Content.ReadAsAsync<IEnumerable<AsteroidApiModel>>();
    //            return asteroidApiData;
    //        }
    //        catch (Exception ex)
    //        {
    //            // Handle API request errors here
    //            throw new Exception("Failed to fetch asteroid data from the NASA API.", ex);
    //        }
    //    }
    //}

    //public async Task<APOD> GetAstronomyPictureOfTheDayAsync(DateTime date)
    //{
    //    // Implement API request logic to fetch astronomy picture
    //    // Example: Fetch astronomy picture of the day from the NASA API
    //    var response = await _httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?date={date:yyyy-MM-dd}&api_key={_apiKey}");

    //    if (response.IsSuccessStatusCode)
    //    {
    //        var json = await response.Content.ReadAsStringAsync();
    //        // Parse the JSON response into an AstronomyPictureModel object
    //        var astronomyPicture = JsonConvert.DeserializeObject<APODService>(json);
    //        return astronomyPicture;
    //    }
    //    else
    //    {
    //        throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
    //    }
    //}
}



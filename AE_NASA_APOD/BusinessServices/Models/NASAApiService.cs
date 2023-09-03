using BusinessServices.Contracts;
using DataAccessModels.Models;
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
}

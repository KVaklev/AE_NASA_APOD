using BusinessQueryParameters;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;
using System.Net.Http.Json;

namespace DataAccessRepositories.Models
{
    public class APODRepository : IAPODRepository
    {
        private readonly INasaHttpClientHelper nasaRepository;

        public APODRepository(INasaHttpClientHelper nasaRepository)
        {
            this.nasaRepository = nasaRepository;
        }

        public async Task<APOD> GetPictureOfTheDay()
        {
            var response = await nasaRepository.GetPictureOfTheDay();
            return await response.Content.ReadFromJsonAsync<APOD>();
        }

        public async Task<APOD> GetAPODByDate(DateTime date)
        {
            var response = await nasaRepository.GetAPODByDate(date);
            return await response.Content.ReadFromJsonAsync<APOD>();
        }

        public async Task<List<APOD>> FilterBy(APODQueryParameters queryParameters)
        {
            var apodOfTheDay = await GetPictureOfTheDay();

                        
            var filteredList = new List<APOD> { apodOfTheDay }; 
                        
            if (queryParameters.Date != null)
            {
                filteredList = filteredList.Where(apod => apod.Date == queryParameters.Date).ToList();
            }

            if (!string.IsNullOrEmpty(queryParameters.Title))
            {
                filteredList = filteredList.Where(apod => apod.Title.Contains(queryParameters.Title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
                        
            return filteredList;
        }
    }
}


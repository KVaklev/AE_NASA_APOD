using BusinessQueryParameters;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

                        
            var filteredList = new List<APOD> { apodOfTheDay }; // Replace with your filtering logic

            // Example: Filter by date
            if (queryParameters.Date != null)
            {
                filteredList = filteredList.Where(apod => apod.Date == queryParameters.Date).ToList();
            }

            // Example: Filter by title
            if (!string.IsNullOrEmpty(queryParameters.Title))
            {
                filteredList = filteredList.Where(apod => apod.Title.Contains(queryParameters.Title, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            
            return filteredList;
        }
    }
}


using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;

namespace BusinessServices.Models
{
    public class APODService : IAPODService
    {
        private readonly IAPODRepository apodRepository;

        public APODService(IAPODRepository apodRepository)
        {
            this.apodRepository = apodRepository;
        }

        public async Task<APOD> GetPictureOfTheDay()
        {
            return await apodRepository.GetPictureOfTheDay();
        }

        public async Task<APOD> GetAPODByDate(DateTime date)
        {
            return await apodRepository.GetAPODByDate(date);
        }

        public async Task<List<APOD>> FilterBy(APODQueryParameters queryParameters)
        {
            return await apodRepository.FilterBy(queryParameters);
        }
    }
}

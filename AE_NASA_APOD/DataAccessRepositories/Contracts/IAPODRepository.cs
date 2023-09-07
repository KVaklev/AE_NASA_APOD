using BusinessQueryParameters;
using DataAccessModels.Models;

namespace DataAccessRepositories.Contracts
{
    public interface IAPODRepository
    {
        Task<APOD> GetPictureOfTheDay();

        Task<APOD> GetAPODByDate(DateTime date);

        Task<List<APOD>> FilterBy(APODQueryParameters queryParameters);
    }
}
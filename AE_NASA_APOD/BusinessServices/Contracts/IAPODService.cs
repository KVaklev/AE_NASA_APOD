using System;
using System.Threading.Tasks;
using BusinessQueryParameters;
using DataAccessModels.Models;

namespace BusinessServices.Contracts
{
    public interface IAPODService
    {
        Task<APOD> GetPictureOfTheDay();

        Task<APOD> GetAPODByDate(DateTime date);

        Task<List<APOD>> FilterBy(APODQueryParameters queryParameters);
    }
}
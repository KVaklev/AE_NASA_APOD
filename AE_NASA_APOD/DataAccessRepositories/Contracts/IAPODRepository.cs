using BusinessQueryParameters;
using DataAccessModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepositories.Contracts
{
    public interface IAPODRepository
    {
        Task<APOD> GetPictureOfTheDay();

        Task<APOD> GetAPODByDate(DateTime date);

        Task<List<APOD>> FilterBy(APODQueryParameters queryParameters);
    }
}
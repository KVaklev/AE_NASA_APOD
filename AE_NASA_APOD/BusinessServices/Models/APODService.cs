using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Models
{
    public class APODService : IAPODService
    {
        private readonly IAPODRepository apodRepository;

        public APODService(IAPODRepository apodRepository)
        {
            this.apodRepository = apodRepository;
        }
        public PaginatedList<APOD> FilterBy(APODQueryParameters queryParameters)
        {
            return this.apodRepository.FilterBy(queryParameters);
        }
        public APOD GetById(int id)
        {
            return this.apodRepository.GetById(id);
        }

        public List<APOD> GetAll()
        {
            return this.apodRepository.GetAll();
        }

    }
}

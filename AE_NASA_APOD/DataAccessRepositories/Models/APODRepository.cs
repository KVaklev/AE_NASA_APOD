using BusinessExceptions;
using BusinessQueryParameters;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;
using System.Net.Http.Json;

namespace DataAccessRepositories.Models
{
    public class APODRepository : IAPODRepository
    {
        private List<APOD> apods;

        private INasaHttpClientHelper nasaRepository;

        public APODRepository(INasaHttpClientHelper nasaRepository)
        {
            this.nasaRepository = nasaRepository; ;

        }
        public async Task<List<APOD>> GetAll()
        {
            var response = await nasaRepository.GetPictureOfTheDay();

            //var result = await response.Content.ReadFromJsonAsync<NeoResult>();

            //var asteroids = result.NearEarthObjects;

            return apods;
        }

        public async Task<PaginatedList<APOD>> FilterBy(APODQueryParameters queryParameters)
        {
            //var response = await nasaRepository.GetPictureOfTheDay();

            //var result = await response.Content.ReadFromJsonAsync<NeoResult>();

            //var apods = result.NearEarthObjects;

            if (!string.IsNullOrEmpty(queryParameters.Copyright))
            {
                apods = apods.FindAll(apod=> apod.Copyright == queryParameters.Copyright);
            }

            if (!string.IsNullOrEmpty(queryParameters.Title))
            {
                apods = apods.FindAll(apod=> apod.Title == queryParameters.Title);    
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy.Equals("title", StringComparison.InvariantCultureIgnoreCase))
                {
                    apods = apods.OrderBy(apod => apod.Title).ToList();
                }

                if (!string.IsNullOrEmpty(queryParameters.SortOrder) && queryParameters.SortOrder.Equals("desc", StringComparison.InvariantCultureIgnoreCase))
                {
                    apods.Reverse();
                }
            }

            int totalPages = (apods.Count() + 1) / queryParameters.PageSize;

            apods = Paginate(apods, queryParameters.PageNumber, queryParameters.PageSize);

            return new PaginatedList<APOD>(apods, totalPages, queryParameters.PageNumber);
        }

        public static List<APOD> Paginate(List<APOD> result, int pageNumber, int pageSize)
        {
            return result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public APOD GetById(int id)
        {
            APOD apod = this.apods.Where(apod => apod.Id == id).FirstOrDefault();

            return apod ?? throw new EntryPointNotFoundException($"APOD with Id = {id} does not exist.");
        }
        public APOD GetByName(string title)
        {
            APOD apod = this.apods.Where(apod=>apod.Title == title).FirstOrDefault();

            return apod ?? throw new EntryPointNotFoundException($"APOD with title = {title} does not exist");
        }

        public APOD GetByCopyright(string copyright)
        {
           APOD apod = this.apods.Where(apod => apod.Copyright == copyright).FirstOrDefault();
            return apod ?? throw new EntryPointNotFoundException($"APOD with copyright = {copyright} does not exist.");
        }

       
    }
}


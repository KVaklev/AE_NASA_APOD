using BusinessExceptions;
using BusinessQueryParameters;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

namespace DataAccessRepositories.Models
{
    public class AsteroidRepository : IAsteroidRepository
    {
        private List<Asteroid> asteroids;

        private INasaHttpClientHelper nasaRepository;

        public AsteroidRepository(INasaHttpClientHelper nasaRepository)
        {
            this.nasaRepository = nasaRepository;
        }

        public async Task<List<Asteroid>> GetAll()
        {
            var response = await nasaRepository.GetAllAsteriodsResponse();

            var result = await response.Content.ReadFromJsonAsync<NeoResult>();

            var asteroids = result.NearEarthObjects;

            return asteroids;
        }
        public async Task<PaginatedList<Asteroid>> FilterBy(AsteroidQueryParameters queryParameters)
        {
            var response = await nasaRepository.GetAllAsteriodsResponse();

            var result = await response.Content.ReadFromJsonAsync<NeoResult>();

            var asteroids = result.NearEarthObjects;

            if(asteroids is null)
            {
                throw new ArgumentException();
            }

            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                asteroids = asteroids.FindAll(asteroid => asteroid.Name == queryParameters.Name);
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                {
                    asteroids = asteroids.OrderBy(asteroid => asteroid.Name).ToList();
                }               
                
                if (!string.IsNullOrEmpty(queryParameters.SortOrder) && queryParameters.SortOrder.Equals("desc", StringComparison.InvariantCultureIgnoreCase))
                {
                    asteroids.Reverse();
                }
            }

            int totalPages = (asteroids.Count() + 1) / queryParameters.PageSize;

            asteroids = Paginate(asteroids, queryParameters.PageNumber, queryParameters.PageSize);

            return new PaginatedList<Asteroid>(asteroids, totalPages, queryParameters.PageNumber);
        }

        public static List<Asteroid> Paginate(List<Asteroid> result, int pageNumber, int pageSize)
        {
            return result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
        }

        public Asteroid GetById(string id)
        {
            Asteroid asteroid = this.asteroids.Where(a => a.Id == id).FirstOrDefault();

            return asteroid ?? throw new EntityNotFoundException($"Asteroid with Id = {id} does not exist.");
        }

        public Asteroid GetByTitle(string name)
        {
            Asteroid asteroid = this.asteroids.Where(a => a.Name == name).FirstOrDefault();

            return asteroid ?? throw new EntityNotFoundException($"Asteroid with title = {name} does not exist.");
        }

    }
}

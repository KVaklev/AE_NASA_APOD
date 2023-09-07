using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;

namespace BusinessServices.Models
{
    public class AsteroidService : IAsteroidService
    {
        private readonly IAsteroidRepository asteroidRepository;

        public AsteroidService(IAsteroidRepository asteroidRepository)
        {
            this.asteroidRepository = asteroidRepository;
        }
        public async Task<List<Asteroid>> GetAll()
        {
            return await this.asteroidRepository.GetAll();
        }
        public async Task<PaginatedList<Asteroid>> FilterBy(AsteroidQueryParameters queryParameters)
        {
            return await this.asteroidRepository.FilterBy(queryParameters);
        }
        public Asteroid GetById(string id)
        {
            return this.asteroidRepository.GetById(id);
        }
    }
}

using BusinessQueryParameters;
using DataAccessModels.Models;

namespace DataAccessRepositories.Contracts
{
    public interface IAsteroidRepository
    {
        Task<List<Asteroid>> GetAll();

        Task<PaginatedList<Asteroid>> FilterBy(AsteroidQueryParameters queryParameters);

        Asteroid GetById(string id);

        Asteroid GetByTitle(string title);         

    }
}

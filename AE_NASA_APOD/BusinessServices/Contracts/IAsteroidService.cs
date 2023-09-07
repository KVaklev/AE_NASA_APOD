using BusinessQueryParameters;
using DataAccessModels.Models;

namespace BusinessServices.Contracts
{
    public interface IAsteroidService
    {
        Task<List<Asteroid>> GetAll();

        Task<PaginatedList<Asteroid>> FilterBy(AsteroidQueryParameters queryParameters);

        Asteroid GetById(string id);        

    }
}

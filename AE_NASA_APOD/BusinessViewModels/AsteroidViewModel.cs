using BusinessDTOs;
using BusinessQueryParameters;
using DataAccessModels.Models;

namespace BusinessViewModels
{
    public class AsteroidViewModel
    {        
        public PaginatedList<Asteroid> Asteroids { get; set; }
        public AsteroidQueryParameters QueryParameters { get; set; } = new AsteroidQueryParameters();
    
    }
}

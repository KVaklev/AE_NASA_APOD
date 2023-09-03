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
    public class AsteroidService : IAsteroidService
    {
        private readonly IAsteroidRepository asteroidRepository;

        public AsteroidService (IAsteroidRepository asteroidRepository)
        {
            this.asteroidRepository = asteroidRepository;
        }
        public List<Asteroid> GetAll()
        {
            return this.asteroidRepository.GetAll();
        }
        public Asteroid GetById(int id)
        {
            return this.asteroidRepository.GetById(id);
        }
        public List<Asteroid> FilterBy(AsteroidQueryParameters asteroidQueryParameters)
        {
            throw new NotImplementedException();
        }


    }
}

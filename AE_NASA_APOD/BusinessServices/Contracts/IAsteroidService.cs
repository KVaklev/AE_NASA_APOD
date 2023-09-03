using BusinessQueryParameters;
using DataAccessModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Contracts
{
    public interface IAsteroidService
    {
        List<Asteroid> GetAll();

        List<Asteroid> FilterBy(AsteroidQueryParameters queryParameters);

        Asteroid GetById(int id);

        //Asteroid Create(Asteroid asteroid);

        //Asteroid Update(Asteroid asteroid);

        //Asteroid Delete(int id);

    }
}

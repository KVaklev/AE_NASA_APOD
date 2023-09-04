using BusinessQueryParameters;
using DataAccessModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepositories.Contracts
{
    public interface IAsteroidRepository
    {
        List<Asteroid> GetAll();

        PaginatedList<Asteroid> FilterBy(AsteroidQueryParameters queryParameters);

        Asteroid GetById(int id);

        Asteroid GetByTitle(string title);

        //Asteroid Create(Asteroid asteroid);

        //Asteroid Update(Asteroid asteroid);

        //Asteroid Delete(int id);    

    }
}

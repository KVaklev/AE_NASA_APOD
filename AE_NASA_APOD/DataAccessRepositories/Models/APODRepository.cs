using BusinessQueryParameters;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepositories.Models
{
    public class APODRepository : IAPODRepository
    {
        private List<APOD> apods;

        public APODRepository()
        {
            this.apods = new List<APOD>()
            {
               new APOD
                {
                    Id = 1,
                    Date = "2023-09-02",
                    Explanation = "These cosmic clouds have blossomed 1,300 light-years away in the fertile starfields of the constellation Cepheus.",
                    Title = "The Iris Nebula",
                    Url = "https://apod.nasa.gov/apod/image/2309/SuperBlueMoon_Saragozza_960.jpg"
                },
                new APOD
                {
                    Id = 2,
                    Date = "2023-08-02",
                    Explanation = "Ceres is the largest asteroid in the asteroid belt between Mars and Jupiter. It's also classified as a dwarf planet and was the first object to be discovered in the asteroid belt. It was discovered in 1801 by Italian astronomer Giuseppe Piazzi.",
                    Title = "Ceres",
                    Url = "https://apod.nasa.gov/apod/image/2309/SuperBlueMoon_Saragozza_960.jpg"
                },
                new APOD
                {
                    Id = 3,
                    Date = "2023-07-02",
                    Explanation = "Vesta is the second-largest asteroid in the asteroid belt. It was discovered in 1807 by German astronomer Heinrich Wilhelm Olbers. NASA's Dawn spacecraft orbited and studied Vesta from 2011 to 2012, providing valuable insights into its composition and history.",
                    Title = "Vesta",
                    Url = "https://apod.nasa.gov/apod/image/2309/SuperBlueMoon_Saragozza_960.jpg"
                },
                new APOD
                {
                    Id = 4,
                    Date = "2023-06-02",
                    Explanation = "Pallas is the third-largest asteroid and was discovered in 1802 by German astronomer Heinrich Wilhelm Olbers. It's named after Pallas Athena, the Greek goddess of wisdom.",
                    Title = "Pallas",
                    Url = "https://apod.nasa.gov/apod/image/2309/SuperBlueMoon_Saragozza_960.jpg"
                },
                new APOD
                {
                    Id = 5,
                    Date = "2023-05-02",
                    Explanation = "Juno is one of the larger asteroids and was discovered in 1804 by German astronomer Karl Harding. It is named after the Roman goddess Juno, who was the queen of the gods.",
                    Title = "Juno",
                    Url = "https://apod.nasa.gov/apod/image/2309/SuperBlueMoon_Saragozza_960.jpg"
                }
            };

        }
        public List<APOD> GetAll()
        {
            return this.apods;
        }

        public PaginatedList<APOD> FilterBy(APODQueryParameters queryParameters)
        {
            List<APOD> result = this.apods;

            if (!string.IsNullOrEmpty(queryParameters.Copyright))
            {
                result = result.FindAll(apod=> apod.Copyright == queryParameters.Copyright);
            }

            if (!string.IsNullOrEmpty(queryParameters.Title))
            {
                result = result.FindAll(apod=> apod.Title == queryParameters.Title);    
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = result.OrderBy(asteroid => asteroid.Copyright).ToList();
                }

                if (!string.IsNullOrEmpty(queryParameters.SortOrder) && queryParameters.SortOrder.Equals("desc", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Reverse();
                }
            }

            int totalPages = (result.Count() + 1) / queryParameters.PageSize;

            result = Paginate(result, queryParameters.PageNumber, queryParameters.PageSize);

            return new PaginatedList<APOD>(result, totalPages, queryParameters.PageNumber);
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


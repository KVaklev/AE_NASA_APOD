using BusinessExceptions;
using BusinessQueryParameters;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;

namespace DataAccessRepositories.Models
{
    public class AsteroidRepository : IAsteroidRepository
    {
        private List<Asteroid> asteroids;

        public AsteroidRepository()
        {
            this.asteroids = new List<Asteroid>()
            {
                new Asteroid
                {
                    Id = 1,
                    Copyright = "Lorand Fenyes",
                    MediaType = "image",
                    DateTime = DateTime.Now,
                    Explanation = "These cosmic clouds have blossomed 1,300 light-years away in the fertile starfields of the constellation Cepheus.",
                    Title = "The Iris Nebula"
                },
                new Asteroid
                {
                    Id = 2,
                    Copyright = "James Hichcock",
                    MediaType = "image",
                    DateTime = DateTime.Now,
                    Explanation = "Ceres is the largest asteroid in the asteroid belt between Mars and Jupiter. It's also classified as a dwarf planet and was the first object to be discovered in the asteroid belt. It was discovered in 1801 by Italian astronomer Giuseppe Piazzi.",
                    Title = "Ceres"
                },
                new Asteroid
                {
                    Id = 3,
                    Copyright = "David Johnson",
                    MediaType = "image",
                    DateTime = DateTime.Now,
                    Explanation = "Vesta is the second-largest asteroid in the asteroid belt. It was discovered in 1807 by German astronomer Heinrich Wilhelm Olbers. NASA's Dawn spacecraft orbited and studied Vesta from 2011 to 2012, providing valuable insights into its composition and history.",
                    Title = "Vesta"
                },
                new Asteroid
                {
                    Id = 4,
                    Copyright = "Michael Brook",
                    MediaType = "image",
                    DateTime = DateTime.Now,
                    Explanation = "Pallas is the third-largest asteroid and was discovered in 1802 by German astronomer Heinrich Wilhelm Olbers. It's named after Pallas Athena, the Greek goddess of wisdom.",
                    Title = "Pallas"
                },
                new Asteroid
                {
                    Id = 5,
                    Copyright = "Damien Jones",
                    MediaType = "image",
                    DateTime = DateTime.Now,
                    Explanation = "Juno is one of the larger asteroids and was discovered in 1804 by German astronomer Karl Harding. It is named after the Roman goddess Juno, who was the queen of the gods.",
                    Title = "Juno"
                }
            };
        }

        public List<Asteroid> GetAll()
        {
            return this.asteroids;
        }
        public PaginatedList<Asteroid> FilterBy(AsteroidQueryParameters queryParameters)
        {
            List<Asteroid> result = this.asteroids;

            if(!string.IsNullOrEmpty(queryParameters.Title))
            {
                result = result.FindAll(asteroid => asteroid.Title == queryParameters.Title);
            }

            if(!string.IsNullOrEmpty(queryParameters.Copyright))
            {
                result = result.FindAll(asteroid => asteroid.Copyright == queryParameters.Copyright);   
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if(queryParameters.SortBy.Equals("title", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = result.OrderBy(asteroid => asteroid.Title).ToList();
                }

                if (queryParameters.SortBy.Equals("copyright", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = result.OrderBy(asteroid => asteroid.Copyright).ToList();
                }

                if (queryParameters.FromDateTime.HasValue)
                {
                    result = result.FindAll(asteroid => asteroid.DateTime >= queryParameters.FromDateTime);
                }

                if (queryParameters.ToDateTime.HasValue)
                {
                    result = result.FindAll(asteroid => asteroid.DateTime <= queryParameters.ToDateTime);
                }

                if (!string.IsNullOrEmpty(queryParameters.SortOrder) && queryParameters.SortOrder.Equals("desc", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Reverse();
                }
            }

            int totalPages = (result.Count() + queryParameters.PageSize - 1) / queryParameters.PageSize;

            result = Paginate(result, queryParameters.PageNumber, queryParameters.PageSize);

            return new PaginatedList<Asteroid>(result, totalPages, queryParameters.PageNumber);
        }

        public static List<Asteroid> Paginate(List<Asteroid> result, int pageNumber, int pageSize)
        {
            return result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
        }

        public Asteroid GetById(int id)
        {
            Asteroid asteroid = this.asteroids.Where(a=>a.Id == id).FirstOrDefault();

            return asteroid ?? throw new EntityNotFoundException($"Asteroid with Id = {id} does not exist.");
        }

        public Asteroid GetByTitle(string title)
        {
            Asteroid asteroid = this.asteroids.Where(a => a.Title == title).FirstOrDefault();

            return asteroid ?? throw new EntityNotFoundException($"Asteroid with title = {title} does not exist.");
        }

    }
}

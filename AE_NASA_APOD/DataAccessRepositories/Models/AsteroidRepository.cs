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
                    Name = "465633 (2009 JR5)",
                    NasaJplUrl="http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=2465633",
                    AbsoluteMagnitude = 20.44,
                    EstimatedMaxDiameter = 0.4853331752,
                    CloseApproachDate = "2015-09-08",
                    VelocityKmH = "65260.5699103704",
                    DistanceKm = "45290298.225725659"
                },
                new Asteroid
                {
                    Id = 2,
                    Name = "(2008 QV11)",
                    NasaJplUrl="http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=3426410",
                    AbsoluteMagnitude = 21.34,
                    EstimatedMaxDiameter = 0.320656449,
                    CloseApproachDate = "2015-09-08",
                    VelocityKmH = "71099.3261312856",
                    DistanceKm = "38764558.550560687"
                },
                new Asteroid
                {
                    Id = 3,
                    Name = "(2010 XT10)",
                    NasaJplUrl="http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=3553060",
                                        AbsoluteMagnitude = 26.5,
                    EstimatedMaxDiameter = 0.0297879063,
                    CloseApproachDate = "2015-09-08",
                    VelocityKmH = "68950.9255988812",
                    DistanceKm = "73563782.385433689"
                },
                new Asteroid
                {
                    Id = 4,
                    Name = "(2015 RC)",
                    NasaJplUrl="http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=3726710",
                    AbsoluteMagnitude = 24.3,
                    EstimatedMaxDiameter = 0.0820427065,
                    CloseApproachDate = "2015-09-08",
                    VelocityKmH = "70151.9167909206",
                    DistanceKm = "4027962.697099799"
                },
                new Asteroid
                {
                    Id = 5,
                    Name = "(2015 RO36)",
                    NasaJplUrl="http://ssd.jpl.nasa.gov/sbdb.cgi?sstr=3727181",
                    AbsoluteMagnitude = 22.9,
                    EstimatedMaxDiameter = 0.1563291544,
                    VelocityKmH = "56899.294813224",
                    DistanceKm = "8084157.219990045"
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

            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                result = result.FindAll(asteroid => asteroid.Name == queryParameters.Name);
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                {
                    result = result.OrderBy(asteroid => asteroid.Name).ToList();
                }               
                
                if (!string.IsNullOrEmpty(queryParameters.SortOrder) && queryParameters.SortOrder.Equals("desc", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Reverse();
                }
            }

            int totalPages = (result.Count() + 1) / queryParameters.PageSize;

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

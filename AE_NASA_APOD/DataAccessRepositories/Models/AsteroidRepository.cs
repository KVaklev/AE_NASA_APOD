﻿using BusinessExceptions;
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
                    MediaType = "image",
                    Date = "2023-09-02",
                    Explanation = "These cosmic clouds have blossomed 1,300 light-years away in the fertile starfields of the constellation Cepheus.",
                    Title = "The Iris Nebula"
                },
                new Asteroid
                {
                    Id = 2,
                    MediaType = "image",
                    Date = "2023-08-02",
                    Explanation = "Ceres is the largest asteroid in the asteroid belt between Mars and Jupiter. It's also classified as a dwarf planet and was the first object to be discovered in the asteroid belt. It was discovered in 1801 by Italian astronomer Giuseppe Piazzi.",
                    Title = "Ceres"
                },
                new Asteroid
                {
                    Id = 3,
                    MediaType = "image",
                    Date = "2023-07-02",
                    Explanation = "Vesta is the second-largest asteroid in the asteroid belt. It was discovered in 1807 by German astronomer Heinrich Wilhelm Olbers. NASA's Dawn spacecraft orbited and studied Vesta from 2011 to 2012, providing valuable insights into its composition and history.",
                    Title = "Vesta"
                },
                new Asteroid
                {
                    Id = 4,
                    MediaType = "image",
                    Date = "2023-06-02",
                    Explanation = "Pallas is the third-largest asteroid and was discovered in 1802 by German astronomer Heinrich Wilhelm Olbers. It's named after Pallas Athena, the Greek goddess of wisdom.",
                    Title = "Pallas"
                },
                new Asteroid
                {
                    Id = 5,
                    MediaType = "image",
                    Date = "2023-05-02",
                    Explanation = "Juno is one of the larger asteroids and was discovered in 1804 by German astronomer Karl Harding. It is named after the Roman goddess Juno, who was the queen of the gods.",
                    Title = "Juno"
                }
            };
        }
        public List<Asteroid> GetAll()
        {
            return this.asteroids;
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
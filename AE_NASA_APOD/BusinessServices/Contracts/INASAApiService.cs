using DataAccessModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Contracts
{
    public interface INASAApiService
    {
        Task<List<Asteroid>> GetAsteroidsAsync(DateTime startDate, DateTime endDate);
        Task<APOD> GetAPODAsync(DateTime date);

    }
}

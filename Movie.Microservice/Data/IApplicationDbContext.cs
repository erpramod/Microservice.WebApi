using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Movie> Movies { get; set; }
        Task<int> SaveChanges();
    }
}

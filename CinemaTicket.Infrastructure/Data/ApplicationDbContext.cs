using CinemaTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}

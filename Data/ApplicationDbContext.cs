using Microsoft.EntityFrameworkCore;
using RestaurantProject.Models;

namespace RestaurantProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reserva> Reserva { get; set; }
    }
}
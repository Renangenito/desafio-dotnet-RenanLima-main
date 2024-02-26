using ExercicioWorkerService.Modelo;
using Microsoft.EntityFrameworkCore;


namespace ExercicioWorkerService.Infra.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<MinhaMensagem> MinhaMensagem { get; set; }
    }
}

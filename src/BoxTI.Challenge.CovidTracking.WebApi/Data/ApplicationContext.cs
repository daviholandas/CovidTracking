using System.Linq;
using BoxTI.Challenge.CovidTracking.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.Challenge.CovidTracking.WebApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}
        
        public DbSet<Location> Locations { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(125)");
            }
        }
    }
}
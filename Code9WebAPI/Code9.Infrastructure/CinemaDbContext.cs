using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Code9.Infrastructure
{
    public class CinemaDbContext : DbContext, IDbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) 
            : base(options)
        {
        }

        private DbSet<Cinema> Cinema { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public Task AddCinema(Cinema cinema)
        {
            Cinema.Add(cinema);
            SaveChanges();

            return Task.CompletedTask;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Genres)
                .WithMany(e => e.Movies);
            
            base.OnModelCreating(modelBuilder);
        }

        public Task<List<Cinema>> GetAllCinema()
        {
            return Cinema.ToListAsync(default);
        }

        public Task UpdateCinema(Cinema cinema)
        {
            Cinema.Update(cinema);
            return Task.CompletedTask;
        }

        public Task DeleteCinema(Cinema cinema)
        {
            Cinema.Remove(cinema);
            return Task.CompletedTask;

        }

        public Task<Cinema> GetCinema(Guid id)
        {
            return Cinema.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
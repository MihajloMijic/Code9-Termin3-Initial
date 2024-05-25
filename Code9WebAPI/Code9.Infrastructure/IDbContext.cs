using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Code9.Infrastructure
{
    public interface IDbContext
    {
        public Task AddCinema(Cinema cinema);

        public Task<List<Cinema>> GetAllCinema();

        public Task UpdateCinema(Cinema cinema);

        public Task DeleteCinema(Cinema cinema);

        public Task<Cinema> GetCinema(Guid id);
    }
}

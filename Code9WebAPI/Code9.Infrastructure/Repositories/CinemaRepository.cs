using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Code9.Infrastructure.Repositories;

public class CinemaRepository : ICinemaRepository
{
    private readonly IDbContext _dbContext;
    
    public CinemaRepository(
        IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Cinema>> GetAllCinema()
    {
        return await _dbContext.GetAllCinema();
    }

    public async Task<Cinema> AddCinema(Cinema cinema)
    {
        _dbContext.AddCinema(cinema);

        return cinema;
    }

    public async Task<Cinema> UpdateCinema(Cinema cinema)
    {
        _dbContext.UpdateCinema(cinema);

        return cinema;
    }

    public async Task DeleteCinema(Cinema cinema)
    {
        _dbContext.DeleteCinema(cinema);
    }

    public async Task<Cinema> GetCinema(Guid id)
    {
        return await _dbContext.GetCinema(id);
    }
}
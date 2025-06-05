using Microsoft.EntityFrameworkCore;
using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Repository;
using StarWarsGeeks.Database.Context;

namespace StarWarsGeeks.Database;
public class PlanetRepository : IPlanetRepository
{
    private readonly SwapiDbContext swapiDbContext;

    public PlanetRepository(SwapiDbContext swapiDbContext)
    {
        this.swapiDbContext = swapiDbContext;
    }

    public async Task<List<Planet>> GetAllPlanetsAsync()
    {
        return await swapiDbContext.Planets.ToListAsync();
    }

    public Task<Planet?> GetPlanetByName(string name)
    {
        return swapiDbContext.Planets.FirstOrDefaultAsync(x => x.Name == name);
    }
}

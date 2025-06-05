using Microsoft.EntityFrameworkCore;
using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Repository;
using StarWarsGeeks.Database.Context;

namespace StarWarsGeeks.Database;
public class PlanetRepository : IPlanetRepository
{
    private readonly StarWarsDbContext starWarsDbContext;

    public PlanetRepository(StarWarsDbContext starWarsDbContext)
    {
        this.starWarsDbContext = starWarsDbContext;
    }

    public async Task<List<Planet>> GetAllPlanetsAsync()
    {
        return await starWarsDbContext.Planets.ToListAsync();
    }

    public Task<Planet?> GetPlanetByName(string name)
    {
        return starWarsDbContext.Planets.FirstOrDefaultAsync(x => x.Name == name);
    }
}

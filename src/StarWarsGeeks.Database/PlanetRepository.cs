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

    public async Task<Planet?> GetPlanetByName(string name)
    {
        Planet? result = await starWarsDbContext.Planets.FirstOrDefaultAsync(x => x.Name == name);
        if (result is null)
        {
            return result;
        }

        result.TimesSearched = result.TimesSearched + 1;
        await starWarsDbContext.SaveChangesAsync();

        return result;
    }
}

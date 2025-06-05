using StarWarsGeeks.Business.Models;

namespace StarWarsGeeks.Business.Repository;
public interface IPlanetRepository
{
    Task<Planet?> GetPlanetByName(string name);
    Task<List<Planet>> GetAllPlanetsAsync();
}

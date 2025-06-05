using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Common;

namespace StarWarsGeeks.Business.Service;
public interface IPlanetService
{
    Task<Result<Planet>> GetPlanetAsync(string name);
    Task<Result<List<Planet>>> GetAllPlanetsAsync();
}

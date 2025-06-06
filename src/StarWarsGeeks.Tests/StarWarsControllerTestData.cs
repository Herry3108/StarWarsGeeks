using StarWarsGeeks.Business.Models;

namespace StarWarsGeeks.Tests;
public static class StarWarsControllerTestData
{
    public static IEnumerable<Person> GetPersonTestData()
    {
        return
        [
            new()
            {
                Name = "Luke Skywalker",
                Height = "172",
                Mass = "77",
                HairColor = "blond",
                SkinColor = "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "https://swapi.info/api/planets/1"
            },
            new()
            {
                Name = "C-3PO",
                Height = "167",
                Mass = "75",
                HairColor = "n/a",
                SkinColor = "gold",
                EyeColor = "yellow",
                BirthYear = "112BBY",
                Gender = "n/a",
                Homeworld = "https://swapi.info/api/planets/1"
            }
        ];
    }

    public static IEnumerable<Planet> GetPlanetTestData()
    {
        return
        [
            new()
            {
                Name = "Tatooine",
                RotationPeriod = "23",
                OrbitalPeriod = "304",
                Diameter = "10465",
                Climate = "arid",
                Gravity = "1 standard",
                Terrain = "desert",
                SurfaceWater = "1",
                Population = "200000"
            },
            new()
            {
                Name = "Alderaan",
                RotationPeriod = "24",
                OrbitalPeriod = "364",
                Diameter = "12500",
                Climate = "temperate",
                Gravity = "1 standard",
                Terrain = "grasslands, mountains",
                SurfaceWater = "40",
                Population = "2000000000"
            }
        ];
    }
}

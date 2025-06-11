using Newtonsoft.Json;

namespace StarWarsGeeks.UI.Service.Models;

public class Planet
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("rotationPeriod")]
    public string RotationPeriod { get; set; } = string.Empty;

    [JsonProperty("orbitalPeriod")]
    public string OrbitalPeriod { get; set; } = string.Empty;

    [JsonProperty("diameter")]
    public string Diameter { get; set; } = string.Empty;

    [JsonProperty("climate")]
    public string Climate { get; set; } = string.Empty;

    [JsonProperty("gravity")]
    public string Gravity { get; set; } = string.Empty;

    [JsonProperty("terrain")]
    public string Terrain { get; set; } = string.Empty;

    [JsonProperty("surfaceWater")]
    public string SurfaceWater { get; set; } = string.Empty;

    [JsonProperty("population")]
    public string Population { get; set; } = string.Empty;

    [JsonProperty("timesSearched")]
    public int TimesSearched;
}
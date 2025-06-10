using Newtonsoft.Json;

namespace StarWarsGeeks.UI.Service.Models;

public class Person
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("height")]
    public string Height { get; set; } = string.Empty;

    [JsonProperty("mass")]
    public string Mass { get; set; } = string.Empty;

    [JsonProperty("hairColor")]
    public string HairColor { get; set; } = string.Empty;

    [JsonProperty("skinColor")]
    public string SkinColor { get; set; } = string.Empty;

    [JsonProperty("eyeColor")]
    public string EyeColor { get; set; } = string.Empty;

    [JsonProperty("birthYear")]
    public string BirthYear { get; set; } = string.Empty;

    [JsonProperty("gender")]
    public string Gender { get; set; } = string.Empty;

    [JsonProperty("homeworld")]
    public string Homeworld { get; set; } = string.Empty;

    [JsonProperty("timesSearched")]
    public int TimesSearched;

}
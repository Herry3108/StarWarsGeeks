using Newtonsoft.Json;

namespace StarWarsGeeks.Business.Models;

public class Person
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("height")]
    public string Height { get; set; } = string.Empty;

    [JsonProperty("mass")]
    public string Mass { get; set; } = string.Empty;

    [JsonProperty("hair_color")]
    public string HairColor { get; set; } = string.Empty;

    [JsonProperty("skin_color")]
    public string SkinColor { get; set; } = string.Empty;

    [JsonProperty("eye_color")]
    public string EyeColor { get; set; } = string.Empty;

    [JsonProperty("birth_year")]
    public string BirthYear { get; set; } = string.Empty;

    [JsonProperty("gender")]
    public string Gender { get; set; } = string.Empty;

    [JsonProperty("homeworld")]
    public string Homeworld { get; set; } = string.Empty;

    [JsonIgnore]
    public int TimesSearched { get; set; } = 0;
}

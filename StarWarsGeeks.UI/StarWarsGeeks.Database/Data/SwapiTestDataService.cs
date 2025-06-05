using Newtonsoft.Json;
using StarWarsGeeks.Business.Models;

namespace StarWarsGeeks.Database.Data;
public class SwapiTestDataService
{
    private readonly HttpClient httpClient;

    public SwapiTestDataService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("StarWarsClient");
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync($"people");
        _ = response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<Person>>(content) ?? [];
    }

    public async Task<List<Planet>> GetPlanetsAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync($"planets");
        _ = response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<Planet>>(content) ?? [];
    }
}

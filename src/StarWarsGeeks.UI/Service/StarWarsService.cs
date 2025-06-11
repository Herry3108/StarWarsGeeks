using Newtonsoft.Json;
using StarWarsGeeks.UI.Service.Models;

namespace StarWarsGeeks.UI.Service;

public class StarWarsService
{
    private readonly HttpClient httpClient;

    public StarWarsService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("StarWarsClient");
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("people");
        _ = response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Person>>(content) ?? [];
    }

    public async Task<List<Planet>> GetPlanetsAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("planets");
        _ = response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Planet>>(content) ?? [];
    }

    public async Task<Person?> GetPersonAsync(string name)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"people/{name}");
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Person>(content);
        }
        return null;
    }

    public async Task<Planet?> GetPlanetAsync(string name)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"planets/{name}");
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Planet>(content);
        }
        return null;
    }
}

using AccountInfo.Data.Models;
using System.Net.Http.Json;

namespace AccountInfo.Web.Services;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Location>?> GetLocationsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Location>>("/api/locations");
    }

    public async Task<List<Loctype>?> GetLoctypesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Loctype>>("/api/loctypes");
    }
}
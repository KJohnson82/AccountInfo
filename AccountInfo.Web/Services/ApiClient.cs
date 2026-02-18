using AccountInfo.Shared.DTOs;

namespace AccountInfo.Web.Services;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<LocationDto>?> GetLocationsAsync()
        => _httpClient.GetFromJsonAsync<List<LocationDto>>("/api/locations");

    public Task<LocationDto?> GetLocationByIdAsync(int id)
        => _httpClient.GetFromJsonAsync<LocationDto>($"/api/locations/{id}");

    public Task<List<LocationDto?>> GetLocationsByLoctypeAsync(int id) 
        => _httpClient.GetFromJsonAsync<List<LocationDto>>($"/api/locations/loctype/{id}");

    public Task<List<LoctypeDto>?> GetLoctypesAsync()
        => _httpClient.GetFromJsonAsync<List<LoctypeDto>>("/api/loctypes");

    public Task<List<InternetAccountDto>?> GetInternetAccountsAsync()
        => _httpClient.GetFromJsonAsync<List<InternetAccountDto>>("/api/internetaccounts");

    public Task<List<InternetAccountDto>?> GetInternetAccountsByLocationAsync(int id)
        => _httpClient.GetFromJsonAsync<List<InternetAccountDto>>($"/api/internetaccounts/{id}");

    public Task<InternetAccountDto?> GetInternetAccountByIdAsync(int id)
        => _httpClient.GetFromJsonAsync<InternetAccountDto>($"/api/internetaccounts/{id}");

    public Task<List<PhoneAccountDto>?> GetPhoneAccountsAsync()
        => _httpClient.GetFromJsonAsync<List<PhoneAccountDto>>("/api/phoneaccounts");
    public Task<List<PhoneAccountDto>?> GetPhoneAccountsByLocationAsync(int id)
        => _httpClient.GetFromJsonAsync<List<PhoneAccountDto>>($"/api/phoneaccounts/{id}");

    public Task<PhoneAccountDto?> GetPhoneAccountByIdAsync(int id)
        => _httpClient.GetFromJsonAsync<PhoneAccountDto>($"/api/phoneaccounts/{id}");

    public Task<List<AccountManagerDto>?> GetAccountManagersAsync()
        => _httpClient.GetFromJsonAsync<List<AccountManagerDto>>("/api/accountmanagers");

    public Task<List<RepairContactDto>?> GetRepairContactsAsync()
        => _httpClient.GetFromJsonAsync<List<RepairContactDto>>("/api/repaircontacts");

}
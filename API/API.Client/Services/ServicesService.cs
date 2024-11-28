using System.Net.Http.Json;
using Domain.Entities;
using Domain.Enums;
using Shared.Dtos.Services;

namespace API.Client.Services;

public class ServicesService
{
    private HttpClient _httpClient;

    public ServicesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ServiceDto> GetServiceAsync(int serviceId)
    {
        return await _httpClient.GetFromJsonAsync<ServiceDto>($"api/Service/{serviceId}");
    }

    public async Task<HttpResponseMessage> GetServicesAsync()
    {
        return await _httpClient.GetAsync("api/Service");
    }

    public async Task<HttpResponseMessage> CreateServiceAsync(CreateServiceDto serviceDto)
    {
        return await _httpClient.PostAsJsonAsync($"api/Service", serviceDto);
    }

    public async Task<HttpResponseMessage> UpdateServiceAsync(ServiceDto serviceDto)
    {
        return await _httpClient.PutAsJsonAsync($"api/Service", serviceDto);
    }

    public async Task<HttpResponseMessage> DeleteServiceAsync(int serviceId)
    {
        return await _httpClient.DeleteAsync($"api/Service/{serviceId}");
    }

    public async Task<HttpResponseMessage> GetByTypeAsync(ServiceType serviceType)
    {
        var url = $"api/Service/by-type?serviceType={serviceType}";
        return await _httpClient.GetAsync(url);
    }
}
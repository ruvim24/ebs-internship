using System.Net.Http.Json;
using Shared.Dtos.Cars;

namespace API.Client.Services;

public class CarService
{
    HttpClient _httpClient;

    public CarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetCustumerCar(int customerId)
    {
        return await _httpClient.GetAsync($"api/Car/getCustumer/{customerId}");
    }

    public async Task<HttpResponseMessage> UpdateCar(UpdateCarDto updateCarDto)
    {
        return await _httpClient.PutAsJsonAsync("api/Car", updateCarDto);
    }

    public async Task<HttpResponseMessage> CreateCar(CreateCarDto createCarDto)
    {
        return await _httpClient.PostAsJsonAsync("api/Car", createCarDto);   
    }
}
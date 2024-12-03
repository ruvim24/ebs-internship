using System.Net.Http.Json;
using Shared.Dtos.Slots;

namespace API.Client.Services;

public class SlotsService
{
    HttpClient _httpClient;

    public SlotsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    

    public async Task<IEnumerable<SlotDto>?> GetMastersAvailableSlotsForDate(int masterId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<SlotDto>>($"api/Slot/masters-available/{masterId}");
    }

    public async Task<SlotDto?> GetSlot(int id)
    {
        return await _httpClient.GetFromJsonAsync<SlotDto>($"api/Slot/{id}");
    }
}
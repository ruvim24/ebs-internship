namespace API.Client.Services;

public class SlotsService
{
    HttpClient _httpClient;

    public SlotsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    

    public async Task<HttpResponseMessage> GetMastersAvailableSlotsForDate(int masterId)
    {
        return await _httpClient.GetAsync($"api/Slot/masters-available/{masterId}");
    }
}
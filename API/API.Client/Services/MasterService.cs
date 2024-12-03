using Shared.Dtos.Users;

namespace API.Client.Services;

public class MasterService
{
    private readonly ServicesService _servicesService;

    public MasterService(ServicesService servicesService)
    {
        _servicesService = servicesService;
    }

    public async Task<bool> HasNotServiceAsync(int userId)
    {
        var response = await _servicesService.GetServiceByMaster(userId);
        return !response.IsSuccessStatusCode;
    }
}

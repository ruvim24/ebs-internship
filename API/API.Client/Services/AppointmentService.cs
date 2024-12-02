using System.Net.Http.Json;
using Domain.Entities;
using Shared.Dtos.Appointments;

namespace API.Client.Services;

public class AppointmentService
{
    private HttpClient _httpClient;

    public AppointmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetMastersService(int serviceId)
    {
        return await _httpClient.GetAsync($"api/Appointment/by-serviceId/{serviceId}") ;
    }
    public async Task<HttpResponseMessage> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
    {
        return await _httpClient.PostAsJsonAsync("api/Appointment", createAppointmentDto);
    }
    
    public async Task<HttpResponseMessage> GetCarAppointments(int carId)
    {
        return await _httpClient.GetAsync($"api/Appointment/carId/{carId}");
    }

    public async Task<HttpResponseMessage> CancelAppointment(int appointmentId)
    {
        return await _httpClient.PutAsync($"api/Appointment/cancel/{appointmentId}", null);
    }

    public async Task<HttpResponseMessage> GetCustomerAppointments()
    {
        return await _httpClient.GetAsync($"api/Appointment/customer-appointments");
    }

    public async Task<HttpResponseMessage> GetMasterAppointments()
    {
        return await _httpClient.GetAsync($"api/Appointment/master-appointments");

    }
}
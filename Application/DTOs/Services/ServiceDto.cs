using Domain.Enums;

namespace Application.DTOs.Services;

public class ServiceDto
{
    public int Id { get; set; }
    public int MasterId { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public ServiceType ServiceType { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
}
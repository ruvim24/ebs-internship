using Domain.Enums;

namespace Application.DTOs.Service;

public class CreateServiceDto
{
    public int MasterId { get; private set; } 
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ServiceType ServiceType { get; private set; }
    public decimal Price { get; private set; }
    public int Duration { get; private set; }
}
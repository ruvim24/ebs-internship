using Domain.Enums;

namespace Application.DTOs.ServiceDtos;

public class UpdateServiceDto
{
    public int Id { get; set; }
    public decimal Price { get; private set; }
    public int Duration { get; private set; }
}
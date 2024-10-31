namespace Application.DTOs.CarDtos;

public class CreateCarDto
{
    public int CustomerId { get; set; }
    public string Maker { get; set; }
    public string Model { get; set; }
    public string PlateNumber { get; set; }
    public string VIN { get; set; }
}
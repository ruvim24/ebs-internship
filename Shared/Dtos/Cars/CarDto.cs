namespace Shared.Dtos.Cars;

public class CarDto
{
    public int Id { get; set; } 
    public int CustomerId { get; set; }
    public string Maker { get; set; }
    public string Model { get; set; }
    public string PlateNumber { get; set; }
    public string VIN { get; set; }
}
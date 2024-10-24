using Domain.Entities.Enums;
using Domain.Entities.ValueObjects;

namespace Application.DTOs.User;

public class UpdateUserDto
{
    public int Id { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; } 
}
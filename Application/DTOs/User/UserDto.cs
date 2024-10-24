using Domain.Entities.Enums;
using Domain.Entities.ValueObjects;

namespace Application.DTOs.User;

public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
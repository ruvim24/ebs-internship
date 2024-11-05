using Domain.Enums;

namespace Application.DTOs.Users;

public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    //public string Password { get; set; }
}
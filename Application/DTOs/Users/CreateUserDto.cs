

using Domain.Enums;

namespace Application.DTOs.Users;

public class CreateUserDto
{
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    //public Role Role  => Role.Customer;
}
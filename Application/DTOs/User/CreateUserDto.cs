using Domain.Entities.Enums;
using Domain.Entities.ValueObjects;

namespace Application.DTOs.User;

public class CreateUserDto
{
    public string FullName { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Password { get; set; }
    
    //va fi automat pe rolul de customer??
    public Role Role  => Role.Customer;
}
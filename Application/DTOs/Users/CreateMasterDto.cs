using Domain.Enums;

namespace Application.DTOs.Users;

public class CreateMasterDto
{
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    
    //va fi automat pe rolul de customer??
    //public Role Role  => Role.Master;
}
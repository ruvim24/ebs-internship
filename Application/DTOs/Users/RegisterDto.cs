using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users;

public class RegisterDto
{
    public string FullName { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }  
    public string ConfirmPassword { get; set; }
    
}
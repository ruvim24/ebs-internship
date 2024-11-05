using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
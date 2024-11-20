namespace Shared.Dtos.Users;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
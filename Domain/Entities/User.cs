using Domain.Enums;
using FluentResults;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        
        private User() { }
        private User(string fullName, string email, string phoneNumber, string password, Role role)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
        }

            public static Result<User> Create(string fullName, string email, string phoneNumber, string password, Role role)
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(fullName))
                    errors.Add("Full name is required.");

                if (string.IsNullOrWhiteSpace(password))
                    errors.Add("Password is required.");
                
                if (errors.Any())
                    return Result.Fail(string.Join(", ", errors));

                return Result.Ok(new User(fullName, email, phoneNumber, password, role));
            }
    }
}

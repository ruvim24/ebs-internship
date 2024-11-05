using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; private set; }
        
        private User() { }
        private User(string fullName, string email, string phoneNumber, string userName) 
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = userName;
        }

            public static Result<User> Create(string fullName, string email, string phoneNumber, string userName) 
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(fullName))
                    errors.Add("Full name is required.");
                
                if (errors.Any())
                    return Result.Fail(string.Join(", ", errors));

                return Result.Ok(new User(fullName, email, phoneNumber, userName));
            }
    }
}

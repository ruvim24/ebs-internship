using Domain.Entities.ObjectValues;
using Domain.Entities.Users.Users;

namespace Domain.Entities.NewFolder
{
    public class User
    {
        public Guid Id { get; set; }
        public FullName FullName { get; set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Contacts Contacts { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        /*public int RoleId { get; set; }*/
        private DateTime CreateddAt => DateTime.UtcNow;

        private User(FullName fullName, Email email, PhoneNumber phoneNumber, string username, string password, UserRole userRole)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;  
            Username = username;
            Password = password;
            Role = userRole;
        }

        public static User Create(FullName fullName, Email email, PhoneNumber phoneNumber, string username, string password, UserRole userRole)
        {
            return new User( fullName, email, phoneNumber, username, password, userRole);
        }
    }
}

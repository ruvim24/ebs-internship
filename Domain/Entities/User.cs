using Domain.Entities.Enums;
using Domain.Entities.ValueObjects;

namespace Domain.Domain.Entitites
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public int? ServiceId { get; private set; }



        private User(string fullName, Email email, PhoneNumber phoneNumber, string password, Role role, int? serviceId)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
            ServiceId = serviceId;
        }

        public User Create(string fullName, Email email, PhoneNumber phoneNumber, string password, Role role, int? serviceId)
        {
            return new User(fullName, email, phoneNumber, password, role, serviceId);
        }
    }
}

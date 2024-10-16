using Domain.Entities.Enums;
using Domain.Entities.ValueObjects;

namespace Domain.Domain.Entitites
{
    public class User
    {
        public int Id { get; set; }
        public FullName FullName { get; set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
        public int? ServiceId { get; set; }
    }
}

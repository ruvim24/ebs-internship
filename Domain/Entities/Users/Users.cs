using Domain.Entities.ObjectValues;
using Domain.Entities.Params;

namespace Domain.Entities.Users
{

    //tabel pentru autentificare si inregisrare       
    public class Users
    {
        public Guid Id { get; set; }
        public FullName FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public UserRole Role { get; set; }
        public int RoleId { get; set; }

        private DateTime CreateddAt => DateTime.UtcNow;

        public Users(UsersParam userParam)
        {
            Id = Guid.NewGuid();
            FullName = userParam.fullName;
            Email = userParam.email;
            Username = userParam.username;
            Password = userParam.password;
            Role = userParam.userRole;
            RoleId = userParam.roleId;

        }
    }
}

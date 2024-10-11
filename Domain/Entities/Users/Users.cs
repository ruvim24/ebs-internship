using Domain.Entities.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{

    //tabel pentru autentificare si inregisrare       
    public class Users
    {
        public int Id { get; set; }
        public FullName FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public UserRole Role { get; set; }
        public int RoleId { get; set; }

        public DateTime CreateddAt => DateTime.UtcNow;
    }
}

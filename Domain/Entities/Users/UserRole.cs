using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class UserRole
    {
        public int Id { get; private set; }
        public RoleType RoleType { get; private set; }

        public UserRole(int id, RoleType roleType)
        {
            Id = id;
            RoleType = roleType;
        }
    }
}

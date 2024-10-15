using Domain.Entities.ObjectValues;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users.Users
{
    public record UsersParam(FullName fullName, string email, string username, string password, UserRole userRole, int roleId);

}

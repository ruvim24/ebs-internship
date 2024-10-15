using Domain.Entities.ObjectValues;

namespace Domain.Entities.Users
{
    public class Admin : BaseUser
    {
        public Admin(FullName fullName, Contacts contacts) : base(fullName, contacts)
        {
        }
    }
}
    
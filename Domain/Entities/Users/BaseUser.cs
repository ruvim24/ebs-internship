using Domain.Entities.ObjectValues;

namespace Domain.Entities.Users
{
    public abstract partial class BaseUser
    {
        public Guid Id { get; private set; }
        public FullName FullName { get; private set; }
        public Contacts Contacts { get; private set; }

        protected BaseUser(FullName fullName, Contacts contacts)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Contacts = contacts;
        }
    }
}

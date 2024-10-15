namespace Domain.Entities.Users.Users
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

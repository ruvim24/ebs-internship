using System.Numerics;

namespace Domain.Entities.Users
{
    public abstract class BaseUser
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Surename { get; set; }
        private string Adress { get; set; }
        private string Email { get; set; }
        //public string Password { get; set; }
        private string PhoneNumber { get; set; }

        protected BaseUser(int userId, string name, string surename, string adress, string email, string phoneNumber)
        {
            Id = userId;
            Name = name;
            Surename = surename;
            Adress = adress;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}

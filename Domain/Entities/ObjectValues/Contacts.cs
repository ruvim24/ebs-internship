namespace Domain.Entities.ObjectValues
{
    public class Contacts
    {
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address  Adress { get; private set; }

        public Contacts(Email email, PhoneNumber phoneNumber, string street, string city, string postalCode) 
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = new Address(street, city, postalCode);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ObjectValues
{
    public class Contacts
    {
        public string Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address  Adress { get; private set; }

        public Contacts(string email, PhoneNumber phoneNumber, string street, string city, string postalCode) 
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = new Address(street, city, postalCode);
        }

    }
}

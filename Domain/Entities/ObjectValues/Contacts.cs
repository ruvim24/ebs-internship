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
        public string PhoneNumber { get; private set; }
        public string  Adress { get; private set; }

        public Contacts(string email, string phoneNumber, string adress) 
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
        public void ChangeEmail(string email)
        {
            Email = email;
        }
        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
        public void ChangAdress(string adress)
        {
            Adress = adress;
        }

    }
}

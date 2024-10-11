using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities.ObjectValues
{
    public class PhoneNumber
    {
        private readonly string _value;

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidPhoneNumber(value))
            {
                throw new ArgumentException("Numărul de telefon invalid.");
            }
            _value = value;
        }

        public override string ToString() => _value;

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // O validare simplă (poate fi extinsă pentru formate specifice)
            return Regex.IsMatch(phoneNumber, @"^\+?\d{10,15}$");
        }
    }

}

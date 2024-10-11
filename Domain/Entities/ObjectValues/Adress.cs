using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ObjectValues
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string PostalCode { get; }

        public Address(string street, string city, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Strada nu poate fi goală.");
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("Orașul nu poate fi gol.");
            if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("Codul poștal nu poate fi gol.");

            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public override string ToString() => $"{Street}, {City}, {PostalCode}";
    }

}

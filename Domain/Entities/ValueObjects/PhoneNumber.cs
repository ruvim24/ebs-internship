using System.Text.RegularExpressions;

namespace Domain.Entities.ValueObjects
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

using System.Text.RegularExpressions;

namespace Domain.Entities.ValueObjects
{
    public class PhoneNumber
    {
        public readonly string Value;

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidPhoneNumber(value))
            {
                throw new ArgumentException("Numărul de telefon invalid.");
            }
            Value = value;
        }

        public override string ToString() => Value;

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // O validare simplă (poate fi extinsă pentru formate specifice)
            return Regex.IsMatch(phoneNumber, @"^\+?\d{10,15}$");
        }
    }

}

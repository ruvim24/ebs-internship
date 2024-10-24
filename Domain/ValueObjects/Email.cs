using System.Text.RegularExpressions;

namespace Domain.Entities.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidEmail(value))
            {
                throw new ArgumentException("Adresa de email invalidă.");
            }
            Value = value;
        }

        public override string ToString() => Value;

        private bool IsValidEmail(string email)
        {
            // A simple validation using a regex pattern for email addresses
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@") || !IsValidEmail(value))
                throw new ArgumentException("Email non valida");
            Value = value;
        }

        private bool IsValidEmail(string email)
        {
            var atIndex = email.IndexOf('@');
            var dotIndex = email.LastIndexOf('.');

            return email.Count(c => c == '@') == 1 && atIndex > 0 && dotIndex > atIndex && dotIndex < email.Length - 2;
        }
    }
}

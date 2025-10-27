using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Phone
    {
        private const int NUMBER_LENGHT = 10;
        public string Prefix { get; }
        public string Number { get; }
        public Phone(string prefix, string number)
        {
            if (!prefix.Contains("+")) { throw new ArgumentException("invalid prefix, prefix must contain  'x' "); }
            if (number.Count() != NUMBER_LENGHT) { throw new ArgumentException($"invalid phone number, length must be {NUMBER_LENGHT}"); }
            Prefix = prefix;
            Number = number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record CAP
    {
        public int Value; 
        public CAP(int value)
        {
            if (value < 10000 || value > 99999)
            {
                throw new ArgumentOutOfRangeException("...");
            }
            Value = value;
        }
    }
}

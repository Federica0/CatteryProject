using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record ItalianTaxCode
    {
       public string Value { get; }
      
        public ItalianTaxCode(string value )
        {
            
            if (!string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("the tax code cannot be null or empty");
            }
            if(value.Length != 16 )
            {
                throw new ArgumentException("the tax code must cointain 16 chars, included letters and numbers");
            }
            Value = value;
            return;
        }
    }
}

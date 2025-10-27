using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class User
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _surname = value;
                }
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _address = value;
                }
            }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("...");
                }
                City = value;
            }
        }
        private Phone _phoneNumber;
        public Phone PhoneNumber { get; set; }
        
        private Email _email;
        public Email Email { get; set; }
        private CAP _cap;
        public CAP Cap { get; set; }
        private ItalianTaxCode _fiscalCode;
        public ItalianTaxCode FisicalCode {  get; set; }   
        

        public User(string name, string surname, string address, Phone phoneNumber,
            Email email, CAP cap, ItalianTaxCode fisicalCode)
        {
            Name = name;
            Surname = surname;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Cap = cap;
            FisicalCode = fisicalCode;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Cat)
            {
                User user = obj as User;
                if (this.Name == user.Name && this.Surname == user.Surname && this.Address == user.Address &&
                    this.PhoneNumber == user.PhoneNumber && this.Email == user.Email &&
                    this.Cap == user.Cap && this.FisicalCode == user.FisicalCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

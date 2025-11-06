using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Cat
    {
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else { throw new ArgumentException("invalid value"); }
            }
        }
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _gender = value;

                }else
                {
                    throw new ArgumentException("invalid value");
                }
                    
            }
        }

        private string _breed;
        public string Breed
        {
            get { return _breed; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _breed = value;

                }else
                {
                    throw new ArgumentException("invalid value");
                }
                   
            }
        }
        private string? _description;
        public string? Description
        {
            get { return _description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _description = value;
                }else
                {
                    throw new ArgumentException("invalid value");
                }
                    

            }
        }

        public readonly string IdentificativeCode;
        private DateOnly _arriveDate;
        public DateOnly ArriveDate
        {
            get { return _arriveDate; }
            set
            {
                if(value < DateOnly.FromDateTime(DateTime.Now))
                {
                    _arriveDate =value;
                }
                else
                {
                    throw new ArgumentException("Arrive date cannot be lower than brirth date or greater than exit date");
                }
            }
        }
        private DateOnly? _exitDate;
        public DateOnly? ExitDate
        {
            get { return _exitDate; }
            set
            {
                if (value < DateOnly.FromDateTime(DateTime.Now) && value > ArriveDate)
                {
                    _exitDate = value;
                }else
                {
                    throw new ArgumentException("...");
                }
                    
            }
        }
        private DateOnly? _birthDate;
        public DateOnly? BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value==null||(ArriveDate > value && ExitDate > value))
                {
                    _birthDate = value;
                }else
                {
                    throw new ArgumentException("...");
                }
                    
            }
        }
        
        public Cat(string name, string gender, string breed, string? description,DateOnly? birthDate, DateOnly arriveDate, DateOnly? extiDate)

        {
            Name = name;
            Gender = gender;
            Breed = breed;
            Description = description;
            ArriveDate = arriveDate;
            ExitDate = extiDate;
            BirthDate = birthDate;
            IdentificativeCode = GenerateCode(arriveDate);
            
        }
        public Cat(string name, string sex, string breed, string? description, DateOnly? birthDate, DateOnly arriveDate, 
            DateOnly? extiDate = null, string? identificativeCode = null): this(name, sex, breed, description, birthDate,
             arriveDate, extiDate) 
        {
            if(identificativeCode == null)
            {
                identificativeCode= GenerateCode(arriveDate);
            }
            else
            {
                IdentificativeCode = identificativeCode;
            }
               
        }

        //costruttore che mi fa passare in ingresso il codice identificativo 
        private string GenerateRandomNumber()
        {
             Random random = new Random();
            return random.Next(10000, 100000).ToString();
        }

        private string GenerateRandomAlphabetChar()
        {
            Random random = new Random();
            int n = 3;
            int AInAscii = 65;
            int ZInAscii = 90;
            string toReturn = "";
            for (int i = 0; i < n; i++)
            {
                toReturn += (char)random.Next(AInAscii, ZInAscii + 1);
            }
            return toReturn;
        }

        private char GetFirstMonthChar(DateOnly date)
        {
            //prende la prima lettera del mese 
            return date.ToString("MMMM")[0];
        }

        private string GenerateCode(DateOnly date)
        {
            string number = GenerateRandomNumber();
            string letter = GenerateRandomAlphabetChar();
            string year = date.Year.ToString();
            char letterMonth = GetFirstMonthChar(date);
            return (number + letterMonth + year + letter).ToUpper();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Cat)
            {
                Cat cat = obj as Cat;
                if (this.IdentificativeCode == cat.IdentificativeCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

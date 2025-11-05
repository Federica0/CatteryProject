using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Interfaces
{
    public interface ICatRepository
    {
        void AddCat(Cat cat);
        void DeleteCat(Cat cat);
        void DeleteCat(string code);
        void UpdateCat(Cat code);
        Cat? GetCatByCode(string code);
        IEnumerable<Cat> GetAllCats();

    }
}

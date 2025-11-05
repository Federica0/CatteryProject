using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);       
        IEnumerable<User> GetAllUsers();
    }
}

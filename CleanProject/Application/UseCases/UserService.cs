using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;


namespace Application.UseCases
{
    public class UserService
    {
        private readonly IUserRepository _repositoryUser;
        public UserService(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        public void Add(UserDto dto)
        {
            User person = dto.ToEntity();
            _repositoryUser.AddUser(person);
        }

    }
}

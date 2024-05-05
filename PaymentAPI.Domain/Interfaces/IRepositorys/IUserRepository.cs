using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.Interfaces.Repositorys
{
    public interface IUserRepository : IGeneric<User>
    {
        Task<UserDTO> Create(UserCreateDTO model);
        Task<List<UserDTO>> Read();
        Task<UserDTO> Read(int id);
        Task<UserDTO> Update(UserUpdateDTO model);
        Task Delete(int id);
    }
}

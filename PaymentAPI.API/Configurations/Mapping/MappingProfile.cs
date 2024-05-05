using AutoMapper;
using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Models;

namespace PaymentAPI.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<Account, AccountDTO>();
            CreateMap<Payment, PaymentDTO>();
            CreateMap<AccountCreateDTO, Account>();
        }
    }
}

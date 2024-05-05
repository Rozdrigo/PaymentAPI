using AutoMapper;
using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Interfaces.Repositorys;
using PaymentAPI.Domain.Models;
using PaymentAPI.Infrastructure.Context;

namespace PaymentAPI.Infrastructure.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly PaymentAPIContext _context;
        private readonly IMapper _mapper;

        public UserRepository(PaymentAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        private bool comparePasswords(string actPassword, string newPassword) {
            // desacoplamento do metodo de comparação de senhas.
            // caso necessario implementar criptografia a comparação de hash's pode ser feita aqui.
            return actPassword.Equals(newPassword);
        }
        private string hashPasswords(string password)
        {
            return password;
        }

        public Task<UserDTO> Create(UserCreateDTO model)
        {
            try
            {
                User newUser = _mapper.Map<UserCreateDTO, User>(model);

                _context.Users.Add(newUser);
                _context.SaveChanges();

                UserDTO userResponse = _mapper.Map<User, UserDTO>(newUser);

                return Task.FromResult(userResponse);
            }catch(Exception ex)
            {
                throw new Exception("Não foi possivel criar usuario: " + ex.Message);
            }
        }
        public Task<List<UserDTO>> Read()
        {
            try
            {
                List<User> users = _context.Users.ToList();

                List<UserDTO> usersReponse = _mapper.Map<List<User>, List<UserDTO>>(users);

                return Task.FromResult(usersReponse);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar usuarios: " + ex.Message);
            }
        }
        public Task<UserDTO> Read(int id)
        {
            try
            {
                User user = _context.Users.Find(id);

                if(user is not null)
                {
                    UserDTO userResponse = _mapper.Map<User, UserDTO>(user);

                    return Task.FromResult(userResponse);
                }
                else
                {
                    throw new Exception("Usuario não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar usuarios: " + ex.Message);
            }
        }
        public Task<UserDTO> Update(UserUpdateDTO model)
        {
            try
            {
                if(model is not null)
                {
                    User actUser = _context.Users.Find(model.Id);

                    if(actUser is not null)
                    {

                        if (model.NewPassword is null) {
                            actUser.Name = model.Name;
                            actUser.Email = model.Email;
                            actUser.CPF = model.CPF;
                        }
                        else
                        {
                            if(comparePasswords(actUser.Password, model.CurrentPassword))
                            {
                                actUser.Password = hashPasswords(model.NewPassword);
                                actUser.Name = model.Name;
                                actUser.Email = model.Email;
                                actUser.CPF = model.CPF;
                            }
                            else
                            {
                                throw new Exception("Credênciais incorretas");
                            }
                        }

                        _context.Users.Update(actUser);
                        _context.SaveChanges();

                        UserDTO userResponse = _mapper.Map<User, UserDTO>(actUser);

                        return Task.FromResult(userResponse);
                    }
                    else
                    {
                        throw new Exception("Não foi possivel encontrar usuario");
                    }
                }
                else
                {
                    throw new Exception("O corpo da requisição não pode ser nulo");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel criar usuario: " + ex.Message);
            }
        }
        public Task Delete(int id)
        {
            try
            {
                User user = _context.Users.Find(id);

                if (user is not null)
                {
                    _context.Users.Remove(user);
                    return Task.CompletedTask;
                }
                else
                {
                    throw new Exception("Usuario não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel remover usuario: " + ex.Message);
            }
        }
    }
}

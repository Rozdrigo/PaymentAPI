using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Interfaces.Repositorys;

namespace PaymentAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpPost("Create")]
        public ActionResult<UserDTO> Create(UserCreateDTO model)
        {
            try
            {
                Task<UserDTO> userCreate = _userRepository.Create(model);
                return Ok(userCreate.Result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Read")]
        public ActionResult<UserDTO> Read()
        {
            try
            {
                Task<List<UserDTO>> userList = _userRepository.Read();
                return Ok(userList.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Read/{id}")]
        public ActionResult<UserDTO> Read(int id)
        {
            try
            {
                Task<UserDTO> user = _userRepository.Read(id);
                return Ok(user.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public ActionResult<UserDTO> Update(UserUpdateDTO model)
        {
            try
            {
                Task<UserDTO> updatedUser = _userRepository.Update(model);
                return Ok(updatedUser.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Delete")]
        public ActionResult<UserDTO> Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return Ok("Usuario deletado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

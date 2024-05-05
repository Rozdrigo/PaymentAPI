using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Interfaces.Repositorys;

namespace PaymentAPI.API.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accontRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accontRepository = accountRepository;
        }

        [HttpPost("Create")]
        public ActionResult<AccountDTO> Create([FromBody] AccountCreateDTO model)
        {
            try
            {
                Task<AccountDTO> accountCreate = _accontRepository.Create(model);
                return Ok(accountCreate.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Read")]
        public ActionResult<AccountDTO> Read()
        {
            try
            {
                Task<List<AccountDTO>> accountList = _accontRepository.Read();
                return Ok(accountList.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Read/{id}")]
        public ActionResult<AccountDTO> Read(int id)
        {
            try
            {
                Task<AccountDTO> account = _accontRepository.Read(id);
                return Ok(account.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public ActionResult<AccountDTO> Update(AccountUpdateDTO model)
        {
            try
            {
                Task<AccountDTO> updatedUser = _accontRepository.Update(model);
                return Ok(updatedUser.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _accontRepository.Delete(id);
                return Ok("Conta deletado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

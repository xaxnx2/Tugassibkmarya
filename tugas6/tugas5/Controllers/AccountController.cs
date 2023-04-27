using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tugas4.Models;
using tugas5.Repositories.Data;
using tugas5.Repositories.Interface;
using tugas5.ViewModels;


namespace tugas5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var Account = _accountRepository.GetAll();
            //Handle ketika data tidak ada/ kosong

            return Ok(new ResponseDataVM<IEnumerable<Account>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Account
            });
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string employee_nik)
        {
            var Account = _accountRepository.GetById(employee_nik);
            if (Account == null)
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Id Not Found"
                });

            return Ok(new ResponseDataVM<Account>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Account
            });
        }

        [HttpPost]
        public ActionResult Insert(Account Account)
        {
            if (Account.password == "" || Account.password.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var insert = _accountRepository.Insert(Account);
            if (insert > 0)
                return Ok(new ResponseDataVM<University>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success",
                    Data = null!
                });

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }

        [HttpPut]
        public ActionResult Update(Account Account)
        {
            if (Account.password == "" || Account.password.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var update = _accountRepository.Update(Account);
            if (update > 0)
                return Ok(new ResponseDataVM<University>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Update Success",
                    Data = null!
                });

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Update Failed / Lost Connection"
            });
        }

        [HttpDelete("{employee_nik}")]
        public ActionResult Delete(string employee_nik)
        {
            var delete = _accountRepository.Delete(employee_nik);
            if (delete > 0)
                return Ok(new ResponseDataVM<University>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Delete Success",
                    Data = null!
                });

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Delete Failed / Lost Connection"
            });
        }

    }
}

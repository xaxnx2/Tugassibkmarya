using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tugas4.Models;
using tugas5.Repositories.Interface;
using tugas5.ViewModels;


namespace tugas5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountroleController : ControllerBase
    {

        private readonly IAccountRoleRepository _AccountRoleRepository;
        public AccountroleController(IAccountRoleRepository AccountRoleRepository)
        {
            _AccountRoleRepository = AccountRoleRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var Accountrole = _AccountRoleRepository.GetAll();
            //Handle ketika data tidak ada/ kosong

            return Ok(new ResponseDataVM<IEnumerable<Accountrole>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Accountrole
            });;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var Accountrole = _AccountRoleRepository.GetById(id);
            if (Accountrole == null)
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Id Not Found"
                });

            return Ok(new ResponseDataVM<Accountrole>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Accountrole
            });
        }

        [HttpPost]
        public ActionResult Insert(Accountrole Accountrole)
        {
            if (Accountrole.account_nik == "" || Accountrole.account_nik.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var insert = _AccountRoleRepository.Insert(Accountrole);
            if (insert > 0)
                return Ok(new ResponseDataVM<Accountrole>
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
        public ActionResult Update(Accountrole Accountrole)
        {
            if (Accountrole.account_nik == "" || Accountrole.account_nik.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var update = _AccountRoleRepository.Update(Accountrole);
            if (update > 0)
                return Ok(new ResponseDataVM<Accountrole>
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var delete = _AccountRoleRepository.Delete(id);
            if (delete > 0)
                return Ok(new ResponseDataVM<Accountrole>
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

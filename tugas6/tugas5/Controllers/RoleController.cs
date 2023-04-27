using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using Tugas4.Models;
using tugas5.Repositories.Data;
using tugas5.Repositories.Interface;
using tugas5.ViewModels;


namespace tugas5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleRepository _RoleRepository;
        public RoleController(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var Roles = _RoleRepository.GetAll();
            //Handle ketika data tidak ada/ kosong

            return Ok(new ResponseDataVM<IEnumerable<Role>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Roles
            });
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var Role = _RoleRepository.GetById(id);
            if (Role == null)
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Id Not Found"
                });

            return Ok(new ResponseDataVM<Role>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Role
            });
        }

        [HttpPost]
        public ActionResult Insert(Role Role)
        {
            if (Role.name == "" || Role.name.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var insert = _RoleRepository.Insert(Role);
            if (insert > 0)
                return Ok(new ResponseDataVM<Role>
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
        public ActionResult Update(Role Role)
        {
            if (Role.name == "" || Role.name.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var update = _RoleRepository.Update(Role);
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var delete = _RoleRepository.Delete(id);
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

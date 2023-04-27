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
    public class ProfilingController : ControllerBase
    {

        private readonly IProfilingRepository _ProfilingRepository;
        public ProfilingController(IProfilingRepository ProfilingRepository)
        {
            _ProfilingRepository = ProfilingRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var Profiling = _ProfilingRepository.GetAll();
            //Handle ketika data tidak ada/ kosong

            return Ok(new ResponseDataVM<IEnumerable<Profiling>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Profiling
            });
        }

        [HttpGet("{employee_nik}")]
        public ActionResult GetById(string employee_nik)
        {
            var Profiling = _ProfilingRepository.GetById(employee_nik);
            if (Profiling == null)
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Id Not Found"
                });

            return Ok(new ResponseDataVM<Profiling>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Profiling
            });
        }

        [HttpPost]
        public ActionResult Insert(Profiling Profiling)
        {
            if (Profiling.EmployeeNIK == "" || Profiling.EmployeeNIK.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var insert = _ProfilingRepository.Insert(Profiling);
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
        public ActionResult Update(Profiling Profiling)
        {
            if (Profiling.EmployeeNIK == "" || Profiling.EmployeeNIK.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var update = _ProfilingRepository.Update(Profiling);
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
        public ActionResult Delete(string employee_nik)
        {
            var delete = _ProfilingRepository.Delete(employee_nik);
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

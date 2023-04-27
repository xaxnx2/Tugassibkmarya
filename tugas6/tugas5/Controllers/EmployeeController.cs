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
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeController(IEmployeeRepository EmployeeController)
        {
            _EmployeeRepository = EmployeeController;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var Employee = _EmployeeRepository.GetAll();
            //Handle ketika data tidak ada/ kosong
            if (Employee == null)
            
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Id Not Found"
                
            });

            return Ok(new ResponseDataVM<IEnumerable<Employee>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Employee
            });

        }

        [HttpGet("{employee_nik}")]
        public ActionResult GetById(string nik)
        {
            var Employee = _EmployeeRepository.GetById(nik);
            if (Employee == null)
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Id Not Found"
                });

            return Ok(new ResponseDataVM<Employee>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = Employee
            });
        }

        [HttpPost]
        public ActionResult Insert(Employee Employee)
        {
            if (Employee.FirstName == "" || Employee.FirstName.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var insert = _EmployeeRepository.Insert(Employee);
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
        public ActionResult Update(Employee Employee)
        {
            if (Employee.FirstName == "" || Employee.FirstName.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }

            var update = _EmployeeRepository.Update(Employee);
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
        public ActionResult Delete(string nik)
        {
            var delete = _EmployeeRepository.Delete(nik);
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

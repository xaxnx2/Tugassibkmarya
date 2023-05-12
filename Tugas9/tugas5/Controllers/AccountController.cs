using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tugas6.Models;
using tugas6.Repositories.Data;
using tugas6.Repositories.Interface;
using tugas6.ViewModels;
using tugas6.Basecontroller;
using tugas6.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using API.Handlers;

namespace tugas6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : GenericController<IAccountRepository, Account, string>
    {
        private readonly ITokenService _tokenService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountsController(
            IAccountRepository repository,
            ITokenService tokenService,
            IEmployeeRepository employeeRepository,
            IAccountRoleRepository accountRoleRepository) : base(repository)
        {
            _tokenService = tokenService;
            _employeeRepository = employeeRepository;
            _accountRoleRepository = accountRoleRepository;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = _repository.Login(loginVM);
            if (!login)
            {
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Login Failed, Account or Password Not Found!"
                });
            }

            var claims = new List<Claim>() {
            new Claim("Email", loginVM.Email),
            new Claim("FullName", _employeeRepository.GetFullNameByEmail(loginVM.Email))
            };

            var getRoles = _accountRoleRepository.GetRolesByEmail(loginVM.Email);
            foreach (var role in getRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = _tokenService.GenerateToken(claims);

            return Ok(new ResponseDataVM<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login Success",
                Data = token
            });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = _repository.Register(registerVM);
            if (register > 0)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success"
                });
            }

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }
    }
    /*public class AccountController : GenericController<IAccountRepository, Account, string>
    {
        public AccountController(IAccountRepository repository) : base(repository) {}

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = _repository.Register(registerVM);
            if (register > 0)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success",
                });
            }
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = _repository.Login(loginVM);
            if (login)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Login Success",
                });
            }
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Login Failed / account or password not found"
            });
        }
    }*/
}

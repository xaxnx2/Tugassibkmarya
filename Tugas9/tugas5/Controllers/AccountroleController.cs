using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using API.Basecontroller;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountroleController : GenericController<IAccountRoleRepository, Accountrole, int>
    {
        public AccountroleController(IAccountRoleRepository repository) : base(repository)
        {
        }
    }
}

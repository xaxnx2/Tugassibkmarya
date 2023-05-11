using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using Tugas6.Models;
using tugas6.Repositories.Data;
using tugas6.Repositories.Interface;
using tugas6.ViewModels;
using tugas6.Basecontroller;

namespace tugas6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<IRoleRepository, Role, int>
    {
        public RoleController(IRoleRepository repository) : base(repository)
        {
        }
    }
}

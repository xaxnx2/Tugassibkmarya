using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using API.Basecontroller;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : GenericController<IEducationRepository, Education, int>
    {
        public EducationController(IEducationRepository repository) : base(repository)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolRegistrationAPI.Service;
using SchoolRegistrationAPI.Models;

namespace SchoolRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly ISchoolService _schoolService;
        public StateController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        [HttpGet]
        public async Task<ActionResult<List<State>>> GetAllState()
        {
            return await _schoolService.GetAllState();
        }
    }
}

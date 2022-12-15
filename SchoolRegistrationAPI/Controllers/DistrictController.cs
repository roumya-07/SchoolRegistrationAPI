using Microsoft.AspNetCore.Mvc;
using SchoolRegistrationAPI.Models;
using SchoolRegistrationAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : Controller
    {
        private readonly ISchoolService _schoolService;
        public DistrictController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        [HttpGet("{StateID}")]
        public async Task<ActionResult<List<District>>> GetAllDistrict(int StateID)
        {
            return await _schoolService.GetAllDistrict(StateID);
        }
    }
}

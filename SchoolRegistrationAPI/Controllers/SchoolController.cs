using Microsoft.AspNetCore.Mvc;
using SchoolRegistrationAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolRegistrationAPI.Models;

namespace SchoolRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SchoolRegistrationEntity>>> GetAllSchool()
        {
            return await _schoolService.GetAllSchool();
        }
        [HttpGet("{SchoolID}")]
        public async Task<ActionResult<SchoolRegistrationEntity>> GetSchoolById(int SchoolID)
        {
            var prod = await _schoolService.GetSchoolById(SchoolID);

            if (prod == null)
            {
                return NotFound();
            }
            return prod;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SchoolRegistrationEntity>> InsertOrUpdate(int id, SchoolRegistrationEntity SR)
        {
            if (id != SR.SchoolID)
            {
                return BadRequest();
            }
            try
            {
                await _schoolService.InsertOrUpdate(SR);

                return CreatedAtAction("GetAllSchool", new { id = SR.SchoolID }, SR);
            }

            catch (Exception ex)
            {
                if (GetSchoolById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpDelete("{SchoolID}")]
        public async Task<ActionResult<SchoolRegistrationEntity>> Delete(int SchoolID)
        {
            var prod = await _schoolService.GetSchoolById(SchoolID);
            if (prod == null)
            {
                return NotFound();
            }
            await _schoolService.Delete(SchoolID);
            return prod;
        }
    }
}

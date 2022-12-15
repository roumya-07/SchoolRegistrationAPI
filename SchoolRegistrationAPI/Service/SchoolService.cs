using SchoolRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolRegistrationAPI.Repository;

namespace SchoolRegistrationAPI.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public async Task<List<State>> GetAllState()
        {
            return await _schoolRepository.GetAllState();
        }

        public async Task<List<District>> GetAllDistrict(int StateID)
        {
            return await _schoolRepository.GetAllDistrict(StateID);
        }

        public async Task<List<SchoolRegistrationEntity>> GetAllSchool()
        {
            return await _schoolRepository.GetAllSchool();
        }

        public async Task<SchoolRegistrationEntity> GetSchoolById(int SchoolID)
        {
            return await _schoolRepository.GetSchoolById(SchoolID);
        }

        public async Task<int> InsertOrUpdate(SchoolRegistrationEntity SR)
        {
            return await _schoolRepository.InsertOrUpdate(SR);
        }
        public async Task<int> Delete(int SchoolID)
        {
            return await _schoolRepository.Delete(SchoolID);
        }
    }
}

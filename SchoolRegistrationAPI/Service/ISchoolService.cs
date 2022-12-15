using SchoolRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistrationAPI.Service
{
    public interface ISchoolService
    {
        public Task<List<SchoolRegistrationEntity>> GetAllSchool();
        public Task<List<State>> GetAllState();
        public Task<List<District>> GetAllDistrict(int StateID);
        public Task<SchoolRegistrationEntity> GetSchoolById(int SchoolID);
        public Task<int> InsertOrUpdate(SchoolRegistrationEntity SR);
        public Task<int> Delete(int SchoolID);
    }
}

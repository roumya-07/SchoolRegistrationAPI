using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolRegistrationAPI.Models;

namespace SchoolRegistrationAPI.Repository
{
    public interface ISchoolRepository
    {
        public Task<List<SchoolRegistrationEntity>> GetAllSchool();
        public Task<List<State>> GetAllState();
        public Task<List<District>> GetAllDistrict(int StateID);
        public Task<SchoolRegistrationEntity> GetSchoolById(int SchoolID);
        public Task<int> InsertOrUpdate(SchoolRegistrationEntity SR);
        public Task<int> Delete(int SchoolID);
    }
}

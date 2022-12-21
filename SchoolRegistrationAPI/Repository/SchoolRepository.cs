using Dapper;
using Microsoft.Extensions.Configuration;
using SchoolRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegistrationAPI.Repository
{
    public class SchoolRepository : BaseRepository, ISchoolRepository
    {
        public SchoolRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<List<State>> GetAllState()
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "FillState");
            var lstste = cn.Query<State>("SP_SchoolRegistration", param, commandType: CommandType.StoredProcedure).ToList();
            return lstste;
        }
        public async Task<List<District>> GetAllDistrict(int StateID)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@StateID", StateID);
            param.Add("@Action", "FillDistrict");
            var lstdis = cn.Query<District>("SP_SchoolRegistration", param, commandType: CommandType.StoredProcedure).ToList();
            return lstdis;
        }
        public async Task<List<SchoolRegistrationEntity>> GetAllSchool()
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Action", "FillTable");
            var lstsch = cn.Query<SchoolRegistrationEntity>("SP_SchoolRegistration", param, commandType: CommandType.StoredProcedure).ToList();
            return lstsch;
        }
        public async Task<SchoolRegistrationEntity> GetSchoolById(int SchoolID)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@SchoolID", SchoolID);
            param.Add("@action", "SelectOne");
            var lstsch = cn.Query<SchoolRegistrationEntity>("SP_SchoolRegistration", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            cn.Close();
            return lstsch;
        }
        public async Task<int> InsertOrUpdate(SchoolRegistrationEntity SR)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@SchoolID", SR.SchoolID);
                param.Add("@StateID", SR.StateID);
                param.Add("@DistrictID", SR.DistrictID);
                param.Add("@SchoolName", SR.SchoolName);
                param.Add("@SchoolTypeID", SR.SchoolTypeID);
                param.Add("@SchoolLevel", SR.SchoolLevel);
                param.Add("@SchoolPhoto", SR.SchoolPhoto);
                param.Add("@Action", "InsertOrUpdate");
                int x = cn.Execute("SP_SchoolRegistration", param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
        public async Task<int> Delete(int SchoolID)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@SchoolID", SchoolID);
            param.Add("@Action", "Delete");
            int x = cn.Execute("SP_SchoolRegistration", param, commandType: CommandType.StoredProcedure);
            cn.Close();
            return x;
        }
    }
}

using System;
using System.Threading.Tasks;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Services
{
    public interface ICourseInfoService
    {
        Task<Course> GetById(int id);
    }
}
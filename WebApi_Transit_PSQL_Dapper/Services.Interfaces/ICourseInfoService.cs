using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Services
{
    public interface ICourseInfoService
    {
        Task<Course>                GetById(int id);
        Task<IEnumerable<Course>>   GetAll();
        Task<int>                   Add(Course course);
        Task<Course>                Present(Course course);
        Task<int>                   Update(int id, Course course);
        Task<int>                   Delete(int id);
    }
}
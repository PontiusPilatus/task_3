using System;
using System.Threading.Tasks;
using WebApi_Transit_PSQL_Dapper.Models;
using WebApi_Transit_PSQL_Dapper.Services;

namespace WebApi_Transit_PSQL_Dapper.BusinessLogic
{
    public class GetCoursesInfoRequestHandler
    {
        private readonly ICourseInfoService _courseInfoService;

        public GetCoursesInfoRequestHandler(ICourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }

        public Task<Course> Handle(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Некорректный идентификатор", nameof(id));
            }

            return _courseInfoService.GetById(id);
        }
    }
}
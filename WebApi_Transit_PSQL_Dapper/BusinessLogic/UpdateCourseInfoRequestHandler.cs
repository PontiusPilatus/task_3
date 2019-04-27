using System;
using System.Threading.Tasks;
using WebApi_Transit_PSQL_Dapper.Models;
using WebApi_Transit_PSQL_Dapper.Services;

namespace WebApi_Transit_PSQL_Dapper.BusinessLogic
{
    public class UpdateCourseInfoRequestHandler
    {
        private readonly ICourseInfoService _courseInfoService;
        public UpdateCourseInfoRequestHandler(ICourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }

        public Task Handle(int id, Course course)
        {

            if (id != course.Id)
            {
                throw new Exception("id и id объекта не совпадают");
            }
            return _courseInfoService.Update(id, course);
        }
    }
}

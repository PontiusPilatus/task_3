using System;
using System.Threading.Tasks;
using WebApi_Transit_PSQL_Dapper.Models;
using WebApi_Transit_PSQL_Dapper.Services;

namespace WebApi_Transit_PSQL_Dapper.BusinessLogic
{
    public class AddCourseInfoRequestHandler
    {
        private readonly ICourseInfoService _courseInfoService;
        public AddCourseInfoRequestHandler(ICourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }

        public Task<int> Handle(Course course)
        {
            var result = _courseInfoService.Present(course).Result;
            if (result != null)
            {
                throw new Exception("Курс уже был добавлен!");
            }
            return _courseInfoService.Add(course);
        }
    }
}

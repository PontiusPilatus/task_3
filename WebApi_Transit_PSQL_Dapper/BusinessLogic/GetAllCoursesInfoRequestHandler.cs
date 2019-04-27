using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Transit_PSQL_Dapper.Models;
using WebApi_Transit_PSQL_Dapper.Services;

namespace WebApi_Transit_PSQL_Dapper.BusinessLogic
{
    public class GetAllCoursesInfoRequestHandler
    {
        // IoC
        private readonly ICourseInfoService _courseInfoService;
        // Autofac builder
        public GetAllCoursesInfoRequestHandler(ICourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }

        public Task<IEnumerable<Course>> Handle()
        {
            return _courseInfoService.GetAll();
        }
    }
}

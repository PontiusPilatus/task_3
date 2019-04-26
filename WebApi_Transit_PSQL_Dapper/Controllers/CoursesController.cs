using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_Transit_PSQL_Dapper.BusinessLogic;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Controllers
{
    
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly GetCoursesInfoRequestHandler _getCoursesInfoRequestHandler;

        public CoursesController(GetCoursesInfoRequestHandler getCoursesInfoRequestHandler)
        {
            _getCoursesInfoRequestHandler = getCoursesInfoRequestHandler;
        }

        [HttpGet("{id}")]
        public Task<Course> GetCourseInfo(int id)
        {
            return _getCoursesInfoRequestHandler.Handle(id);
        }
    }
    
}
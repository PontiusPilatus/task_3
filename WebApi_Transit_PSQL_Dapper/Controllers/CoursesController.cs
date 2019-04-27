﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebApi_Transit_PSQL_Dapper.BusinessLogic;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Controllers
{
    
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly GetCoursesInfoRequestHandler _getCoursesInfoRequestHandler;
        private readonly GetAllCoursesInfoRequestHandler _getAllCoursesInfoRequestHandler;
        private readonly AddCourseInfoRequestHandler _addCourseInfoRequestHandler;
        private readonly UpdateCourseInfoRequestHandler _updateCourseInfoRequestHandler;
        private readonly DeleteCourseInfoRequestHandler _deleteCourseInfoRequestHandler;
        private readonly IBus _bus;
        public CoursesController(GetCoursesInfoRequestHandler getCoursesInfoRequestHandler,
                                 GetAllCoursesInfoRequestHandler getAllCoursesInfoRequestHandler,
                                 AddCourseInfoRequestHandler addCourseInfoRequestHandler,
                                 UpdateCourseInfoRequestHandler updateCourseRequestHandler,
                                 DeleteCourseInfoRequestHandler deleteCourseInfoRequestHandler,
                                 IBus bus)
        {
            _getCoursesInfoRequestHandler = getCoursesInfoRequestHandler;
            _getAllCoursesInfoRequestHandler = getAllCoursesInfoRequestHandler;
            _addCourseInfoRequestHandler = addCourseInfoRequestHandler;
            _updateCourseInfoRequestHandler = updateCourseRequestHandler;
            _deleteCourseInfoRequestHandler = deleteCourseInfoRequestHandler;
            _bus = bus;
        }

        [HttpGet]
        public Task<IEnumerable<Course>> GetAllCoursesInfo()
        {
            return _getAllCoursesInfoRequestHandler.Handle();

        }
        [HttpGet("{id}")]
        public Task<Course> GetCourseInfo(int id)
        {
            return _getCoursesInfoRequestHandler.Handle(id);
        }

        [HttpPost]
        public Task AddCourseInfo(Course course)
        {
            return _addCourseInfoRequestHandler.Handle(course);
        }

        [HttpPut("{id}")]
        public async Task UpdateCourseInfo(int id, Course course)
        {
            //return _updateCourseInfoRequestHandler.Handle(id, course);
            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>> UPDATE {id}: {course.Name}");
            await _bus.Publish<UpdateMessage>(
                new { Id = id, Course = course });
            return;
        }

        [HttpDelete("{id}")]
        public Task DeleteCourseInfo(int id)
        {
            return _deleteCourseInfoRequestHandler.Handle(id);
        }
    }
    
}
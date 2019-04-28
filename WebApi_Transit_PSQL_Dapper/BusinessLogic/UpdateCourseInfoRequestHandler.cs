using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebApi_Transit_PSQL_Dapper.BusinessLogic.Consumers;
using WebApi_Transit_PSQL_Dapper.Models;
using WebApi_Transit_PSQL_Dapper.Services;

namespace WebApi_Transit_PSQL_Dapper.BusinessLogic
{
    public class UpdateCourseInfoRequestHandler
    {
//        private readonly ICourseInfoService _courseInfoService;
        private readonly IBus _bus;
        public UpdateCourseInfoRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(int id, Course course)
        {
            if (id != course.Id)
            {
                throw new Exception("id и id объекта не совпадают");
            }
            return _bus.Send<UpdateMessage>(new UpdateMessage {Id = id, Course = course});
        }
    }
}

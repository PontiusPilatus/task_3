using System;
using System.Threading.Tasks;
using MassTransit;
using WebApi_Transit_PSQL_Dapper.Models;
using WebApi_Transit_PSQL_Dapper.Services;

namespace WebApi_Transit_PSQL_Dapper.BusinessLogic.Consumers
{
    public class UpdateCourseInfoMessageHandler : IConsumer<UpdateMessage>
    {
        private readonly ICourseInfoService _courseInfoService;

        public UpdateCourseInfoMessageHandler(ICourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }

        public Task Consume(ConsumeContext<UpdateMessage> context)
        {
            _courseInfoService.Update(context.Message.Id,
                                             context.Message.Course);
            return Task.CompletedTask;
        }
    }
}

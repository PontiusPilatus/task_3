using System;
using System.Threading.Tasks;
using MassTransit;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Bus.Consumers
{
    /// <summary>
    /// Consumer that will handle info request from controller
    /// </summary>
    public class GetCourseInfoConsumer : IConsumer<Course>
    {
        public Task Consume(ConsumeContext<Course> context)
        {
            Console.WriteLine(
                $"Caught a message: {context.Message.Id} {context.Message.Name} {context.Message.Hours}");
            
            return Task.CompletedTask;
        }
    }
}
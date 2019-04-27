using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Controllers
{
    [Route("api/bus")]
    public class BusTestController : ControllerBase
    {
        private readonly IBus _bus;

        public BusTestController(IBus bus)
        {
            _bus = bus;
        }

        public async Task Index()
        {
            await _bus.Publish<Course>(
                new {Id = 13, Name="Make", Hours=104});
        }
    }
}
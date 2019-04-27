using System;
using System.Threading.Tasks;
using WebApi_Transit_PSQL_Dapper.Services;

namespace WebApi_Transit_PSQL_Dapper.BusinessLogic
{
    public class DeleteCourseInfoRequestHandler
    {
        ICourseInfoService _courseInfoService;
        public DeleteCourseInfoRequestHandler(ICourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }

        public Task Handle(int id)
        {
            return _courseInfoService.Delete(id);
        }
    }
}

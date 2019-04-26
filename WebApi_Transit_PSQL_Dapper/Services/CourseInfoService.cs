using System;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Services
{
    public class CourseInfoService : ICourseInfoService
    {
        private const string ConnectionString =
            "host=localhost;port=5432;database=test;username=test;password=test";
        public async Task<Course> GetById(int id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<Course>(
                    "SELECT * FROM module_task_table WHERE id = @id", new {id = id});
            }
        }
    }
}
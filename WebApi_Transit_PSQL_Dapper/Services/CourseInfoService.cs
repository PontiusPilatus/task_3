using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using WebApi_Transit_PSQL_Dapper.Models;

namespace WebApi_Transit_PSQL_Dapper.Services
{
    public class CourseInfoService : ICourseInfoService
    {
        // CHANGE ME
        private const string ConnectionString =
            "host=localhost;port=5432;database=test;username=test;password=test";

        public async Task<Course> GetById(int id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<Course>(
                    "SELECT * FROM module_task_table WHERE id = @id", new { id });
            }
        }
        public async Task<IEnumerable<Course>> GetAll()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                var result = await connection.QueryAsync<Course>(
                    "SELECT * FROM module_task_table");
                return result.AsList();
            }
        }

        public async Task<int> Add(Course course)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(
                    "INSERT INTO module_task_table (name, hours)" +
                    "VALUES (@name, @hours)", new
                    {
                        name = course.Name, hours = course.Hours
                    });
            }
        }

        public async Task<Course> Present(Course course)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                 
                var result =  await connection.QueryFirstOrDefaultAsync<Course>(
                    "SELECT * FROM module_task_table WHERE id = @id ", new {
                        id = course.Id
                    });
                return result;
            }
        }

        public async Task<int> Update(int id, Course course)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(
                    "UPDATE module_task_table " +
                    "SET name = @name, hours = @hours " +
                    "WHERE id = @id", new
                    {
                        id,
                        name = course.Name,
                        hours = course.Hours
                    });
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(
                    "DELETE FROM module_task_table " +
                    "WHERE id = @id", new { id });
            }
        }
    }
}
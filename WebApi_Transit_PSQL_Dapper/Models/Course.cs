using System;

namespace WebApi_Transit_PSQL_Dapper.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
    }
}
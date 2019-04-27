using System;
namespace WebApi_Transit_PSQL_Dapper.Models
{
    public class UpdateMessage
    {
        public int Id { get; set; }
        public Course Course { get; set; }
    }
}

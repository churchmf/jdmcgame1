using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class QueueController : Controller
    {
        private const string DatabaseConnectionString = @"Server=localhost\SQLEXPRESS;Database=RoboArena;Trusted_Connection=True;";

        /// <summary>
        /// Queues the given robot id for a match
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(int id)
        {
            //TODO guard against already in queue
            int numRowsAffected = 0;
            using (var connection = new SqlConnection(DatabaseConnectionString))
            {
                string query = @"INSERT INTO dbo.MatchQueue VALUES (@id)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                numRowsAffected = command.ExecuteNonQuery();
            }

            if(numRowsAffected != 1)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok();
        }
    }
}

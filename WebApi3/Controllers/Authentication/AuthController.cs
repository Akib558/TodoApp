using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi3.Controllers.Authen
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";

        [HttpGet("{user_id}")]
        public IActionResult Get(int user_id){

            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT session_id FROM SessionTable WHERE user_id = @user_id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", user_id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.Read()){
                        return Ok(reader["session_id"]);
                    }
                    else{
                        return Ok(-1);
                    }
                }

            // return Ok(-1);
        }

        [HttpPost("{user_id}")]
        public IActionResult Post(int user_id){
             using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO SessionTable (user_id) values (@user_id)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", user_id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.Read()){
                        return Get(user_id);
                    }
                    else{
                        return Ok(-1);
                    }
                }

        }

        [HttpDelete("{user_id}")]
        public IActionResult Delete(int user_id){
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM SessionTable WHERE user_id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", user_id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return Ok(1);
                    }
                    else{
                        return Ok(-1);
                    }
                }
            // return Ok();
        }
    }
}


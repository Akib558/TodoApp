using System.Data.SqlClient;
using WebApi3.Repositories.Interfaces;
using WebApi3.Models;

namespace WebApi3.Repositories.Implementations
{
    public class DeleteTodoRepository : IDeleteTodoRepository
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";

        public ResponseClass Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM TODO1 WHERE ID = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return new ResponseClass
                        {
                            Status = "Error",
                            Message = $"Todo with ID {id} not found.",
                            Data = null
                        };
                    }
                }

                return new ResponseClass
                {
                    Status = "Success",
                    Message = $"Todo with ID {id} deleted successfully",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseClass
                {
                    Status = "Error",
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
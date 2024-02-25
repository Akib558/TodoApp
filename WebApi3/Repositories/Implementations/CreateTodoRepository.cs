using System.Data.SqlClient;
using WebApi3.Repositories.Interfaces;
using WebApi3.Models;

namespace WebApi3.Repositories.Implementations
{
    public class CreateTodoRepository : ICreateTodoRepository
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";
        public ResponseClass Post(TodoModelClass todo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO TODO1 (Title, Description, created_time, updated_time, completed_time, isCompleted, labels, mylabels) VALUES (@Title, @Description, @CreatedTime, @UpdatedTime, @CompletedTime, @IsCompleted, @Labels, @MyLabels)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", todo.Title ?? "");
                    command.Parameters.AddWithValue("@Description", todo.Description ?? "");
                    command.Parameters.AddWithValue("@CreatedTime", todo.CreatedTime ?? "");
                    command.Parameters.AddWithValue("@UpdatedTime", todo.UpdatedTime ?? "");
                    command.Parameters.AddWithValue("@CompletedTime", todo.CompletedTime ?? "");
                    command.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted ?? "0");
                    command.Parameters.AddWithValue("@Labels", todo.Labels ?? "");
                    command.Parameters.AddWithValue("@MyLabels", todo.MyLabels ?? "");

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return new ResponseClass
                {
                    Status = "Success",
                    Message = "Todo created successfully",
                    Data = todo
                };
            }
            catch (Exception ex)
            {
                return new ResponseClass
                {
                    Status = "Error on Post",
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
using System.Data.SqlClient;
using WebApi3.Repositories.Interfaces;
using WebApi3.Models;

namespace WebApi3.Repositories.Implementations
{
    public class UpdateTodoRepository : IUpdateTodoRepository
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";

         public ResponseClass Update(int id, TodoModelClass updatedTodo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE TODO1 SET Title = @Title, Description = @Description, created_time = @CreatedTime, updated_time = @UpdatedTime, completed_time = @CompletedTime, isCompleted = @IsCompleted, labels = @Labels, mylabels = @myLabels WHERE ID = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", updatedTodo.Title ?? "");
                    command.Parameters.AddWithValue("@Description", updatedTodo.Description ?? "");
                    command.Parameters.AddWithValue("@CreatedTime", updatedTodo.CreatedTime ?? "");
                    command.Parameters.AddWithValue("@UpdatedTime", updatedTodo.UpdatedTime ?? "");
                    command.Parameters.AddWithValue("@CompletedTime", updatedTodo.CompletedTime ?? "");
                    command.Parameters.AddWithValue("@IsCompleted", updatedTodo.IsCompleted ?? "0");
                    command.Parameters.AddWithValue("@Id", id);
                    updatedTodo.MyLabels = Convert.ToString(String.Join(',', updatedTodo.MyLabels.Split(',').Where(s => !string.IsNullOrWhiteSpace(s))
                                                                .Distinct()
                                                                .ToList())) ?? "";
                    command.Parameters.AddWithValue("@Labels", updatedTodo.Labels ?? "");
                    command.Parameters.AddWithValue("@MyLabels", updatedTodo.MyLabels ?? "");
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return new ResponseClass
                        {
                            Status = "Error on Put",
                            Message = $"Todo with ID {id} not found.",
                            Data = null
                        };
                    }
                }

                return new ResponseClass
                {
                    Status = "Success",
                    Message = $"Todo with ID {id} updated successfully",
                    Data = updatedTodo
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
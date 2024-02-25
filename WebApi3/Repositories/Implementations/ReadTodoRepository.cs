using System.Data.SqlClient;
using WebApi3.Repositories.Interfaces;
using WebApi3.Models;
namespace WebApi3.Repositories.Implementations
{
    public class ReadTodoRepository : IReadTodoRepository
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";

        public ResponseClass Get()
        {
            try
            {
                List<TodoModelClass> todos = new List<TodoModelClass>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Title, Description, created_time, updated_time, completed_time, isCompleted, labels, mylabels FROM TODO1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            TodoModelClass todo = new TodoModelClass
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Title = Convert.ToString(reader["Title"]) ?? "Null Value",
                                Description = Convert.ToString(reader["Description"]) ?? "Null value",
                                CreatedTime = Convert.ToString(reader["created_time"]) ?? "Null value",
                                UpdatedTime = Convert.ToString(reader["updated_time"]) ?? "Null value",
                                CompletedTime = Convert.ToString(reader["completed_time"]) ?? "Null value",
                                IsCompleted = Convert.ToString(reader["isCompleted"]) ?? "0",
                                Labels = Convert.ToString(reader["labels"]) ?? "Null value",
                                MyLabels = Convert.ToString(reader["mylabels"]) ?? "Null value"
                            };
                            todos.Add(todo);
                        }
                    }
                }

                return new ResponseClass
                {
                    Status = "Success",
                    Message = "Todos retrieved successfully",
                    Data = todos
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


        public ResponseClass Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ID, Title, Description, created_time, updated_time, completed_time, isCompleted, labels, mylabels FROM TODO1 WHERE ID = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        TodoModelClass todo = new TodoModelClass
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Title = Convert.ToString(reader["Title"]) ?? "Null Value",
                            Description = Convert.ToString(reader["Description"]) ?? "Null value",
                            CreatedTime = Convert.ToString(reader["created_time"]) ?? "Null value",
                            UpdatedTime = Convert.ToString(reader["updated_time"]) ?? "Null value",
                            CompletedTime = Convert.ToString(reader["completed_time"]) ?? "Null value",
                            IsCompleted = Convert.ToString(reader["isCompleted"]) ?? "0",
                            Labels = Convert.ToString(reader["labels"]) ?? "Null value",
                            MyLabels = Convert.ToString(reader["mylabels"]) ?? "Null value"


                        };
                        return new ResponseClass
                        {
                            Status = "Success",
                            Message = "Todo retrieved successfully",
                            Data = todo
                        };
                    }
                    else
                    {
                        return new ResponseClass
                        {
                            Status = "Error",
                            Message = $"Todo with ID {id} not found",
                            Data = null
                        };
                    }
                }
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
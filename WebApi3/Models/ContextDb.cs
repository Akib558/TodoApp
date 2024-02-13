using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApi3.Models
{
    public class ContextDb
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";

        // Get method with response handling
            // Get method with response handling
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
                                Labels = Convert.ToString(reader["labels"])?? "Null value",
                                MyLabels = Convert.ToString(reader["mylabels"])?? "Null value"
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

        // Get method by ID with response handling
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
                            Labels = Convert.ToString(reader["labels"])?? "Null value",
                            MyLabels = Convert.ToString(reader["mylabels"])?? "Null value"


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


        // Post method with response handling
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
                    command.Parameters.AddWithValue("@Labels", todo.Labels?? "");
                    command.Parameters.AddWithValue("@MyLabels", todo.MyLabels??"");

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
                    Status = "Error",
                    Message = ex.Message,
                    Data = null
                };
            }
        }


        // Update method with response handling
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
                    command.Parameters.AddWithValue("@Labels",updatedTodo.Labels ?? "");
                    command.Parameters.AddWithValue("@MyLabels", updatedTodo.MyLabels?? "");
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

        // Delete method with response handling
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

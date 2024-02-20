using System.Data.SqlClient;
namespace WebApi3.Models.Users
{
    public class UserClass
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";

        // Get method with response handling
        // Get method with response handling
        public ResponseClass Post(RegisterModelClass user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO UserTable (username, password_hash, email, created_at) " +
                                   "VALUES (@Username, @PasswordHash, @Email, @CreatedAt)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@PasswordHash", user.Password);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            return new ResponseClass
                            {
                                Status = "Success",
                                Message = "Todo retrieved successfully",
                                Data = null
                            };
                        }
                        else
                        {
                            return new ResponseClass
                            {
                                Status = "Error",
                                Message = "Registration failed",
                                Data = null
                            };
                        }
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


        public ResponseClass Get(LoginModelClass loginModelClass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserTable WHERE username = @Username and password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", loginModelClass.Username);
                    command.Parameters.AddWithValue("@Password", loginModelClass.Password);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        return new ResponseClass
                        {
                            Status = "Success",
                            Message = "Login successful",
                            Data = null
                        };
                    }
                    else
                    {
                        return new ResponseClass
                        {
                            Status = "Error",
                            Message = "Login failed",
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
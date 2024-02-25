// using System.Data.SqlClient;
using System.Data.SqlClient;

// using Sql.Data.SqlClient;

namespace WebApi3.Models.Users
{
    public class UserClass
    {
        private string connectionString = "Server=(localdb)\\myDB; Database=TodoCrudDB; Trusted_Connection=True;Encrypt=false;";
        // string connectionString = "server=localhost;database=TodoCrudDB;uid=root;password=amijaninaok;";

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
                    // return new ResponseClass
                    // {
                    //     Status = loginModelClass.Password.ToString() + loginModelClass.Username.ToString(),
                    //     Message = "Login successful",
                    //     Data = null
                    // };
                    string query = "SELECT * FROM UserTable WHERE username = @Username and password_hash = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", loginModelClass.Username.ToString());
                    command.Parameters.AddWithValue("@Password", loginModelClass.Password.ToString());

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        return new ResponseClass
                        {
                            Status = "Success",
                            Message = "Login successful",
                            Data = new LoginResponse{
                                user_id = Convert.ToInt16(reader["user_id"])
                            }
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
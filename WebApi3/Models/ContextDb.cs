using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System;
using System.Web;
using System.Configuration;
using System.Linq;
using MySql.Data.MySqlClient;


namespace WebApi3.Models
{
    public class ContextDb
    {

        public List<TodoModelClass> Get()
        {


            string connectionString = "server=localhost;database=TodoCrudDB;uid=root;password=amijaninaok;";


            // string connectionString = "Server= DESKTOP-RVBD9G5\\SQLEXPRESS; Database= TodoCrudDB; Integrated Security=True;";

            List<TodoModelClass> todos = new List<TodoModelClass>();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ID, Title, Description FROM TODO1";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        TodoModelClass todo = new TodoModelClass
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Title = Convert.ToString(reader["Title"]) ?? "Null Value",
                            Description = Convert.ToString(reader["Description"]) ?? "Null value"
                        };
                        // System.Console.WriteLine(todo);
                        todos.Add(todo);
                    }
                }
            }
            return todos;
        }

    }


}

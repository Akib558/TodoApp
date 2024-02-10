using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi3.Models;
using System.Data.SqlClient;

namespace WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAllController
    {

        // public TodoAllController(ContextDb db)
        // {
        //     _db = db;
        // }
        public ContextDb db = new ContextDb();

        [HttpGet]
        public IEnumerable<TodoModelClass> Get()
        {

            return db.Get().ToList();


            // string connectionString =  "Server= DESKTOP-RVBD9G5\\SQLEXPRESS; Database= TodoCrudDB; Integrated Security=True;";

            // List<TodoModelClass> todos = new List<TodoModelClass>();


            // using (SqlConnection connection = new SqlConnection(connectionString))
            // {
            //     string query = "SELECT ID, Title, Description FROM TODO1";

            //     using (SqlCommand command = new SqlCommand(query, connection))
            //     {
            //         connection.Open();
            //         SqlDataReader reader = command.ExecuteReader();

            //         while (reader.Read())
            //         {
            //             TodoModelClass todo = new TodoModelClass
            //             {
            //                 ID = Convert.ToInt32(reader["ID"]),
            //                 Title = Convert.ToString(reader["Title"]),
            //                 Description = Convert.ToString(reader["Description"])
            //             };
            //             // System.Console.WriteLine(todo);
            //             todos.Add(todo);
            //         }
            //     }
            // }

            // return todos.ToList();


        }

        // [HttpGet("{id}")]
        // public ActionResult<TodoModelClass> Get(int id)
        // {
        //     var todo = _db.Get(id);
        //     if (todo == null)
        //     {
        //         return NotFound();
        //     }
        //     return todo;
        // }
    }
}

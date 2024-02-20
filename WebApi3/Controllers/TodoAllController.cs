// using System.Collections.Generic;
// using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi3.Models;
using WebApi3.Models.Users;

namespace WebApi3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoAllController : ControllerBase
    {
        private readonly ContextDb db = new ContextDb();
        private readonly UserClass us = new UserClass();
        [HttpGet]
        public ResponseClass Get()
        {
            return db.Get();
        }

        [HttpPost("login")]

        public IActionResult Get(LoginModelClass loginModel){
            var login = us.Get(loginModel);
            if(login == null){
                return NotFound();
            }
            return Ok(login);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = db.Get(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpGet("labels")]
        public IActionResult GetLabels()
        {
            var todo = db.GetLabels();
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Post(TodoModelClass todo)
        {
            if (todo == null)
            {
                return BadRequest("Invalid data provided.");
            }

            // Set default values for CreatedTime and CompletedTime if not provided in the request
            if (string.IsNullOrEmpty(todo.CreatedTime))
            {
                todo.CreatedTime = DateTime.Now.ToString();
            }
            if (string.IsNullOrEmpty(todo.UpdatedTime))
            {
                todo.UpdatedTime = todo.CreatedTime.ToString();
            }
            if (string.IsNullOrEmpty(todo.CompletedTime))
            {
                todo.CompletedTime = "Not completed yet.";
            }

            if (string.IsNullOrEmpty(todo.IsCompleted))
            {
                todo.IsCompleted = "0";
            }

            try
            {
                var res = db.Post(todo);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("register")]
        public IActionResult Register(RegisterModelClass user)
        {
            // if (todo == null)
            // {
            //     return BadRequest("Invalid data provided.");
            // }

            // // Set default values for CreatedTime and CompletedTime if not provided in the request
            // if (string.IsNullOrEmpty(todo.CreatedTime))
            // {
            //     todo.CreatedTime = DateTime.Now.ToString();
            // }
            // if (string.IsNullOrEmpty(todo.UpdatedTime))
            // {
            //     todo.UpdatedTime = todo.CreatedTime.ToString();
            // }
            // if (string.IsNullOrEmpty(todo.CompletedTime))
            // {
            //     todo.CompletedTime = "Not completed yet.";
            // }

            // if (string.IsNullOrEmpty(todo.IsCompleted))
            // {
            //     todo.IsCompleted = "0";
            // }

            try
            {
                var res = us.Post(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpPut("{id}")]
        public IActionResult Put(int id, TodoModelClass updatedTodo)
        {
            try
            {
                // Set completed time
                if(updatedTodo.IsCompleted == "1"){
                    updatedTodo.CompletedTime = Convert.ToString(DateTime.Now);
                }
                else{
                    updatedTodo.CompletedTime = "Not completed yet.";
                }

                var existingTodo = db.Get(id);
                if (existingTodo == null)
                {
                    return NotFound($"Todo with ID {id} not found.");
                }

                db.Update(id, updatedTodo);
                var updatedItem = db.Get(id); // Fetch the updated todo item from the database
                return Ok(updatedItem); // Return the updated todo item as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingTodo = db.Get(id);
                if (existingTodo == null)
                {
                    return NotFound($"Todo with ID {id} not found.");
                }

                db.Delete(id);
                return Ok(existingTodo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

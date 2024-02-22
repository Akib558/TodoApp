// using System.Collections.Generic;
// using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi3.Models;
using WebApi3.Models.Users;
using WebApi3.Services.Interfaces;

namespace WebApi3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoAllController : ControllerBase
    {
        // private readonly ContextDb db = new ContextDb();
        private readonly ITodoService _todoService;
        private readonly UserClass us = new UserClass();

        public TodoAllController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var res = _todoService.Get();
            return Ok(res);
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
            var res = _todoService.GetById(id);
            return Ok(res);
        }

        [HttpGet("labels")]
        public IActionResult GetLabels()
        {
            var res = _todoService.GetLabels();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(TodoModelClass todo)
        {
           

            var res = _todoService.CreateTodo(todo);
            return Ok(res);


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

                var res = _todoService.UpdateTodo(id, updatedTodo);
                return Ok(res);
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
                var res = _todoService.DeleteTodo(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

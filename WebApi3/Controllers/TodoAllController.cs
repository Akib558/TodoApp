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
        // private readonly ITodoService _todoService;
        private readonly ICreateTodoService _createTodoService;
        private readonly IReadTodoService _readTodoService;
        private readonly IUpdateTodoService _updateTodoService;
        private readonly IDeleteTodoService _deleteTodoService;
        private readonly UserClass us = new UserClass();

        public TodoAllController(IDeleteTodoService deleteTodoService,IUpdateTodoService updateTodoService, ICreateTodoService createTodoService, IReadTodoService readTodoService)
        {
            // _todoService = todoService;
            _createTodoService = createTodoService;
            _readTodoService = readTodoService;
            _updateTodoService = updateTodoService;
            _deleteTodoService = deleteTodoService;
        }

        [HttpPost("login")]

        public IActionResult Get(LoginModelClass loginModel){
            var login = us.Get(loginModel);
            // if(login == null){
            //     return NotFound();
            // }
            return Ok(login);
        }
        

        [HttpPost("register")]
        public IActionResult Register(RegisterModelClass user)
        {
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


        [HttpGet]
        public IActionResult Get()
        {
            var res = _readTodoService.Get();
            return Ok(res);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var res = _readTodoService.GetById(id);
            return Ok(res);
        }


        [HttpPost]
        public IActionResult Post(TodoModelClass todo)
        {
           

            var res = _createTodoService.CreateTodo(todo);
            return Ok(res);


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TodoModelClass updatedTodo)
        {
            try
            {
                var res = _updateTodoService.UpdateTodo(id, updatedTodo);
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
                var res = _deleteTodoService.DeleteTodo(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

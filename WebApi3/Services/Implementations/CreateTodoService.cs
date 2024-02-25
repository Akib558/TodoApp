using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;
using WebApi3.Repositories.Interfaces;
using WebApi3.Services.Interfaces;

namespace WebApi3.Services.Implementations
{
    public class CreateTodoService : ICreateTodoService
    {
        private ICreateTodoRepository _todoRepository;

        public CreateTodoService(ICreateTodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ResponseClass CreateTodo(TodoModelClass todo){
        

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
            return _todoRepository.Post(todo);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;
using WebApi3.Repositories.Interfaces;
using WebApi3.Services.Interfaces;

namespace WebApi3.Services.Implementations
{
    public class DeleteTodoService : IDeleteTodoService
    {
        private IDeleteTodoRepository _todoRepository;
        public ResponseClass DeleteTodo(int id){
            return _todoRepository.Delete(id);
        }
    
    }
}
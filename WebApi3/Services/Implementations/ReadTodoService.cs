using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;
using WebApi3.Repositories.Interfaces;
using WebApi3.Services.Interfaces;

namespace WebApi3.Services.Implementations
{
    public class ReadTodoService : IReadTodoService
    {
        private readonly IReadTodoRepository _todoRepository;

        public ReadTodoService(IReadTodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ResponseClass Get(){
            return _todoRepository.Get();
        }
        public ResponseClass GetById(int id){
             return _todoRepository.Get(id);
        }
    }
}
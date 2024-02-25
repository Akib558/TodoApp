using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;
using WebApi3.Repositories.Interfaces;
using WebApi3.Services.Interfaces;

namespace WebApi3.Services.Implementations
{
    public class UpdateTodoService : IUpdateTodoService
    {
        private IUpdateTodoRepository _todoRepository;

                public ResponseClass UpdateTodo(int id, TodoModelClass updatedTodo){
                            // Set completed time
                if(updatedTodo.IsCompleted == "1"){
                    updatedTodo.CompletedTime = Convert.ToString(DateTime.Now);
                }
                else{
                    updatedTodo.CompletedTime = "Not completed yet.";
                }

            return _todoRepository.Update(id, updatedTodo);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;

namespace WebApi3.Services.Interfaces
{
    public interface ITodoService
    {
        ResponseClass Get();
        ResponseClass GetById(int id);
        ResponseClass GetLabels();
        ResponseClass CreateTodo(TodoModelClass todo);
        ResponseClass UpdateTodo(int id, TodoModelClass updatedTodo);
        ResponseClass DeleteTodo(int id);
    }
}
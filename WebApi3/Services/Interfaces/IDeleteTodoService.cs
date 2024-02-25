using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;

namespace WebApi3.Services.Interfaces
{
    public interface IDeleteTodoService
    {
        ResponseClass DeleteTodo(int id);
    }
}
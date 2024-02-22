using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;


namespace WebApi3.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        ResponseClass Get();
        ResponseClass Get(int id);
        ResponseClass GetLabels();
        ResponseClass Post(TodoModelClass todo);
        ResponseClass Update(int id, TodoModelClass updatedTodo);
        ResponseClass Delete(int id);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi3.Models;

namespace WebApi3.Repositories.Interfaces
{
    public interface IReadTodoRepository
    {
            ResponseClass Get();
        ResponseClass Get(int id);

    
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi3.Services.Interfaces;

namespace WebApi3.Controllers
{

    public class DemoController
    {
        public IReadTodoService ReadTodoService => _readTodoService;
        public ICreateTodoService CreateTodoService => _createTodoService;
        public IDeleteTodoService DeleteTodoService => _deleteTodoService;
        public IUpdateTodoService UpdateTodoService => _updateTodoService;
    
        // private ITodoService _todoService;
        private ICreateTodoService _createTodoService;
        private IReadTodoService _readTodoService;
        private IUpdateTodoService _updateTodoService;
        private IDeleteTodoService _deleteTodoService;

        public DemoController(IDeleteTodoService deleteTodoService,IUpdateTodoService updateTodoService, ICreateTodoService createTodoService, IReadTodoService readTodoService)
        {
            // _todoService = todoService;
            _createTodoService = createTodoService;
            _readTodoService = readTodoService;
            _updateTodoService = updateTodoService;
            _deleteTodoService = deleteTodoService;
        }

    }
}
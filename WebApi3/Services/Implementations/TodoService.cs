using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi3.Models;
using WebApi3.Repositories.Interfaces;
using WebApi3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi3.Models;
using WebApi3.Models.Users;

namespace WebApi3.Services.implementations{
    public class TodoService : ITodoService
    {
        private ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ResponseClass Get(){
            return _todoRepository.Get();
        }

        public ResponseClass GetById(int id){
            return _todoRepository.Get(id);
        }

        public ResponseClass GetLabels(){
            return _todoRepository.GetLabels();
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

        public ResponseClass DeleteTodo(int id){
            return _todoRepository.Delete(id);
        }
    
    }
}
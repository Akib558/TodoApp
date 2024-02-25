using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApi3.Repositories.Implementations;
using WebApi3.Repositories.Interfaces;
// using WebApi3.Services.implementations;
using WebApi3.Services.Implementations;
using WebApi3.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddScoped<ITodoRepository, TodoRepository>();
// builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddScoped<ICreateTodoRepository, CreateTodoRepository>();
builder.Services.AddScoped<IReadTodoRepository, ReadTodoRepository>();
builder.Services.AddScoped<IUpdateTodoRepository, UpdateTodoRepository>();
builder.Services.AddScoped<IDeleteTodoRepository, DeleteTodoRepository>();


builder.Services.AddScoped<ICreateTodoService, CreateTodoService>();
builder.Services.AddScoped<IUpdateTodoService, UpdateTodoService>(); 
builder.Services.AddScoped<IDeleteTodoService, DeleteTodoService>();
builder.Services.AddScoped<IReadTodoService, ReadTodoService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApi3.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//    policy =>
//         {
//             policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//         }     
//     );
// });

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseCors(policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();





////////////

// Manually map TodoAllController
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "todoAll",
        pattern: "/api/todoall",
        defaults: new { controller = "TodoAll", action = nameof(TodoAllController.Get) }
    );

    // Add more controller routes as needed
});

app.Run();


//////////



















// app.MapGet("/api/todoall", ()=> "");

// app.MapGet("/", ()=> "Hello World");


app.Run();

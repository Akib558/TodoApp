using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebApi3.Models;
using WebApi3.Repositories.Implementations;
using WebApi3.Repositories.Interfaces;
// using WebApi3.Services.Implementations;
using WebApi3.Services.Interfaces;
// using WebApi3.Services.implementations;

namespace WebApi3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app...
        }

    }


}

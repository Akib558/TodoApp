using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebApi3.Models;

namespace WebApi3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext to the service container
            services.AddScoped<ContextDb>(); // Assuming ContextDb is scoped to the HTTP request
            // Add other services...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app...
        }

    }


}

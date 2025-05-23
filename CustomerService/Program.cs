
using CustomerService.Models;
using CustomerService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CustomerService
{

    // dotnet new web -o CustomerService -f net9.0
    // cd CustomerService
    // dotnet add package Swashbuckle.AspNetCore
    // dotnet add package Microsoft.EntityFrameworkCore.InMemory
    // dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    // dotnet tool install --global dotnet-ef
    // dotnet add package Microsoft.EntityFrameworkCore.Design
    // dotnet ef migrations add InitialCreate  // ef migrations remove
    // dotnet ef database update

    // Visual Studio
    // Microsoft.EntityFrameworkCore.Tools
    // Add-Migration InitialCreate
    // Update-Database

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection") ?? "Data Source=CustomerDB.db";

            builder.Services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            // Add services to the container.
            // Add services to the container.
            builder.Services.AddScoped<ICustomerService, Services.CustomerService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CustomerService API",
                    Description = "Customer management",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerService API V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}

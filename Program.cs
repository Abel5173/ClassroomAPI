using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ClassroomAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ClassroomContext>(options =>
    {
    var connectionString = builder.Configuration.GetConnectionString("ClassroomConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



// Install Entity Framework: Use NuGet Package Manager to install the Entity Framework package.

// Create a database context: Create a class that derives from DbContext and define DbSet properties for each entity type that you want to include in your data model.

// Configure the database connection string: Configure the connection string in the appsettings.json file or in the ConfigureServices method of the Startup.cs file.

// Register the database context: In the ConfigureServices method of the Startup.cs file, register the database context with the dependency injection container.

// Scaffold a controller: Use the Scaffolding feature of Visual Studio to create a controller and views that perform CRUD (create, read, update, delete) operations for the database context.

// Customize the controller and views: Customize the generated controller and views to suit your needs.

// Test the Web API: Use a tool such as Postman to test the Web API and verify that it is performing as expected.
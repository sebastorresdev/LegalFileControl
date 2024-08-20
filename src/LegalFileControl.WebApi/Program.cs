using LegalFileControl.Application.Services.Users;
using LegalFileControl.Domain.Interfaces;
using LegalFileControl.Domain.Models;
using LegalFileControl.Infrastructure.data;
using LegalFileControl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// configuracion de la base de datos
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
builder.Services.AddDbContext<LegalFileControlDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddTransient<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();


// prueba del servicio de usuarios
app.MapGet("/usuarios", async (IUserService _userService) =>
{
    try
    {
        var response = await _userService.GetAll();
        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.NotFound($"Error: {ex.Message}");
    }
});

app.Run();

using LegalFileControl.Application.Services.Users;
using LegalFileControl.Domain.Interfaces;
using LegalFileControl.Domain.Models;
using LegalFileControl.Infrastructure.data;
using LegalFileControl.Infrastructure.Repositories;
using LegalFileControl.WebApi.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// configuracion de la base de datos
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
builder.Services.AddDbContext<LegalFileControlDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// repositorios
builder.Services.AddTransient<IBaseRepository<User>, UserRepository>();

// modulos
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.MapUserEndpoints();

app.Run();

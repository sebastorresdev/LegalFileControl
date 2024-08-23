using LegalFileControl.Application.DTOs.Users;
using LegalFileControl.Application.Services.Users;

namespace LegalFileControl.WebApi.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/usuarios");

        group.MapGet("/", async (IUserService _userService) =>
        {
            try
            {
                var response = await _userService.GetAll();
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapGet("/{id:int}", async (IUserService _userService, int id) =>
        {
            try
            {
                var response = await _userService.GetById(id);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapPost("/crear", async (IUserService _userService, CreateUserDto createUserDto) =>
        {
            try
            {
                await _userService.Create(createUserDto);
                return Results.Ok("Usuario creado con exito!");
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapPut("/editar/{id:int}", async (IUserService _userService, UpdateUserDto updateUserDto, int id) =>
        {
            try
            {
                await _userService.Update(updateUserDto, id);
                return Results.Ok("Usuario actualizado con exito!");
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        group.MapDelete("eliminar/{id:int}", async (IUserService _userService, int id) =>
        {
            try
            {
                var response = await _userService.Delete(id);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        return group;
    }
}
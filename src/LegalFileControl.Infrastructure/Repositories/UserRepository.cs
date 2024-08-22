using System.Linq.Expressions;
using LegalFileControl.Domain.Interfaces;
using LegalFileControl.Domain.Models;
using LegalFileControl.Infrastructure.data;
using LegalFileControl.Infrastructure.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LegalFileControl.Infrastructure.Repositories;

public class UserRepository(LegalFileControlDbContext dbContext, ILogger<UserRepository> logger) : IBaseRepository<User>
{
    private readonly LegalFileControlDbContext _dbContext = dbContext;
    private DbSet<User> UserModel => _dbContext.Set<User>();
    private readonly ILogger<UserRepository> _logger = logger;

    public async Task<User> CreateAsync(User value)
    {
        try
        {
            _dbContext.Add(value);
            await _dbContext.SaveChangesAsync();
            return value;
        }
        catch (DbUpdateException dbEx)
        {
            _logger.LogError(dbEx, "No se pudo agregar el usuario con Username: {UserName}", value.UserName);
            throw new RepositoryException("Ocurrió un error al intentar guardar un nuevo usuario.", dbEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrió una excepción no controlada al intentar crear un nuevo usuario con Username: {UserName}", value.UserName);
            throw new RepositoryException("Ocurrió una excepción no controlada al intentar crear un nuevo usuario.", ex);
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            var deleteUser = await UserModel.FirstOrDefaultAsync(u => u.Id == id);

            if (deleteUser is null)
            {
                _logger.LogWarning("El usuario con id: {id} no fue encontrado para ser eliminado.", id);
                throw new RepositoryException($"No se encontró un usuario con el id {id}.");
            }

            _dbContext.Remove(deleteUser);
            await _dbContext.SaveChangesAsync();

            return id;
        }
        catch (DbUpdateException dbEx)
        {
            _logger.LogError(dbEx, "Error al intentar eliminar el usuario con id: {Id}", id);
            throw new RepositoryException("Ocurrió un error al intentar eliminar un usuario.", dbEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrió un error no controlado al intentar eliminar el usuario con id: {id}", id);
            throw new RepositoryException("Ocurrió un error no controlado al intentar eliminar un usuario.", ex);
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>>? filter = null)
    {
        try
        {
            return filter is not null
                ? await UserModel.Where(filter).Include(u => u.Role).ToListAsync()
                : await UserModel.Include(u => u.Role).ToListAsync();
        }
        catch (SqlException sqlEx)
        {
            _logger.LogError(sqlEx, "Error de base de datos al intentar obtener la lista de usuarios.");
            throw new RepositoryException("Ocurrió un error al intentar obtener los usuarios.", sqlEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrió una excepción no controlada al intentar obtener la lista de usuarios.");
            throw new RepositoryException("Ocurrió una excepción no controlada al intentar obtener los usuarios.", ex);
        }
    }


    public async Task<User?> GetByIdAsync(int id)
    {
        try
        {
            return await UserModel.FirstAsync(u => u.Id == id);
        }
        catch (InvalidOperationException)
        {
            _logger.LogWarning("El usuario con id: {Id} no fue encontrado.", id);
            throw new RepositoryException($"No se encontró un usuario con el id {id}.");
        }
        catch (SqlException sqlEx)
        {
            _logger.LogError(sqlEx, "Error de base de datos al intentar obtener el usuarios con id: {Id}", id);
            throw new RepositoryException("Ocurrió un error al intentar obtener el usuario.", sqlEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrió una excepción no controlada al intentar obtener el usuarios con id: {Id}", id);
            throw new RepositoryException("Ocurrió una excepción no controlada al intentar obtener el usuario.", ex);
        }
    }

    public async Task<User> UpdateAsync(User value)
    {
        try
        {
            _dbContext.Update(value);
            await _dbContext.SaveChangesAsync();
            return value;
        }
        catch (DbUpdateException dbEx)
        {
            _logger.LogError(dbEx, "Error al intentar actualizar el usuario con id: {Id}", value.Id);
            throw new RepositoryException("Ocurrió un error al intentar actualizar un usuario.", dbEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrió un error no controlado al intentar actualizar el usuario con id: {Id}", value.Id);
            throw new RepositoryException("Ocurrió un error no controlado al intentar actualizar un usuario.", ex);
        }
    }
}
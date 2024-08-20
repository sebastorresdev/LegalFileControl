using System.Linq.Expressions;
using LegalFileControl.Domain.Interfaces;
using LegalFileControl.Domain.Models;
using LegalFileControl.Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace LegalFileControl.Infrastructure.Repositories;

public class UserRepository : IBaseRepository<User>
{
    protected readonly LegalFileControlDbContext _dbContext;
    protected DbSet<User> UserModel => _dbContext.Set<User>();

    public UserRepository(LegalFileControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User> Create(User value)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? filter = null)
    {
        IQueryable<User> query = UserModel;

        if (filter is not null)
        {
            query = query.Where(filter).Include(u => u.Role);
        }
        else
        {
            query = query.Include(u => u.Role);
        }

        return await query.ToListAsync();
    }

    public Task<User?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetFirstOrDefault(Expression<Func<User, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task Update(User value)
    {
        throw new NotImplementedException();
    }
}
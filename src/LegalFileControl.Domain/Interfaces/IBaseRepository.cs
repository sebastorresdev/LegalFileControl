using System.Linq.Expressions;

namespace LegalFileControl.Domain.Interfaces;

public interface IBaseRepository<TModel> where TModel : class
{
    Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? filter = null);
    Task<TModel> GetByIdAsync(int id);
    Task CreateAsync(TModel value);
    Task UpdateAsync(TModel value);
    Task<int> DeleteAsync(int id);
}
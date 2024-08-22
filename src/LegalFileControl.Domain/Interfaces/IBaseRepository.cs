using System.Linq.Expressions;

namespace LegalFileControl.Domain.Interfaces;

public interface IBaseRepository<TModel> where TModel : class
{
    Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? filter = null);
    Task<TModel?> GetByIdAsync(int id);
    Task<TModel> CreateAsync(TModel value);
    Task<TModel> UpdateAsync(TModel value);
    Task<int> DeleteAsync(int id);
}
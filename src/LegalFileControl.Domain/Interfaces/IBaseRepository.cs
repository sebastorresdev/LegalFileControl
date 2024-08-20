using System.Linq.Expressions;

namespace LegalFileControl.Domain.Interfaces;

public interface IBaseRepository<TModel> where TModel : class
{
    Task<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>>? filter = null);
    Task<TModel?> GetById(int id);
    Task<TModel?> GetFirstOrDefault(Expression<Func<TModel, bool>> filter);
    Task<TModel> Create(TModel value);
    Task Update(TModel value);
    Task Delete(int id);
}
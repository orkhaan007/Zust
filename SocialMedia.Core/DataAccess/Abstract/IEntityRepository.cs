using SocialMedia.Core.Abstraction;
using System.Linq.Expressions;

namespace SocialMedia.Core.DataAccess.Abstract;
public interface IEntityRepository<T> where T : class,IEntity, new()
{
    public Task<T> GetAsync(Expression<Func<T,bool>> filter);
    public Task<List<T>> GetListAsync(Expression<Func<T,bool>> ? filter = null);
    public Task AddAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task UpdateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetPostsByUserAsync(string userId);
}
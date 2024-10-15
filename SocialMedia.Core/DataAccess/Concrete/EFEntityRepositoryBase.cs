using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Abstraction;
using SocialMedia.Core.DataAccess.Abstract;
using System.Linq.Expressions;

namespace SocialMedia.Core.DataAccess.Concrete;
public class EFEntityRepositoryBase<TEntity, TContext> 
    : IEntityRepository<TEntity> 
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
                                                                                                                                                    
    private readonly TContext context;
                                                                                                                                                    
    public EFEntityRepositoryBase(TContext context)
    {
        this.context = context;
    }
                                                                                                                                                     
    public async Task AddAsync(TEntity entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> ? filter = null)
    {
        return filter == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity>> GetPostsByUserAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentException("UserId cannot be null or empty.", nameof(userId));
        }

        return await context.Set<TEntity>()
            .Where(post => EF.Property<string>(post, "UserId") == userId)
            .ToListAsync();
    }
}

using BackendData.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace BackendData.DataAccess;


public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _dbContext;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(PaginationFilter? paginationFilter = null)
    {
        if (paginationFilter == null)
        {
            return await _dbContext.Set<T>().ToListAsync();       
        }
        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
        return await _dbContext.Set<T>()
            .Skip(skip)
            .Take(paginationFilter.PageSize)
            .ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}

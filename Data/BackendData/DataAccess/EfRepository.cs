using BackendData.DomainModel;
using BackendData.Extansions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using TaskAPI.Extansions;

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

    public async Task<IReadOnlyList<T>> ListAllAsync(GetAllSortFilter? sort = null, 
        GetAllSearchFilter? filter = null, PaginationFilter? paginationFilter = null)
    {
        var queryble = _dbContext.Set<T>().AsQueryable();

        if (String.IsNullOrEmpty(filter?.SearchName) && paginationFilter?.PageSize == 0 && paginationFilter?.PageNumber == 0)
            return await queryble.ToListAsync();

        if (!String.IsNullOrEmpty(filter?.SearchName))
          queryble = await ApplyFilter(queryble, filter.SearchName);

        var orderBy = String.IsNullOrWhiteSpace(sort?.Column) || String.IsNullOrWhiteSpace(sort?.Sort)
            ? "City ASC"
            : String.Concat(sort.Column, " ", sort.Sort);

        var skip = (paginationFilter!.PageNumber - 1) * paginationFilter!.PageSize;
        
        return await queryble
            .Skip(skip)
            .Take(paginationFilter.PageSize)
            .OrderBy(orderBy)
            .ToListAsync();
    }
  
    private async Task<IQueryable<T>> ApplyFilter(IQueryable<T> source, string filter)
    {
        if (filter.Length == 0)
            return  source;
         
        filter = filter.FirstCharToUpper();

        var propertyInfoCollection = typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => p.Name);
        var type = typeof(T);
       
        var properties = propertyInfoCollection.Select(x => type.GetProperty(x));

        var parameter = Expression.Parameter(type);
        var leftHandSides = properties.Select(
                x => Expression.Property(parameter, x));

        var rightHandSide = Expression.Constant(filter);

        var equalityExpressions = leftHandSides.Select(
                x => Expression.Equal(x, rightHandSide));

        var aggregatedExpressions = equalityExpressions.Aggregate(
                (x, y) => Expression.Or(x, y));

        var lambda = Expression.Lambda<Func<T, bool>>(
                aggregatedExpressions, parameter);

        return  source.Where(lambda);
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

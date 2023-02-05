using Azure;
using BackendData.DomainModel;
using BackendData.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

    public async Task<IReadOnlyList<T>> ListAllAsync(string? filter = null, PaginationFilter? paginationFilter = null)
    {
        var queryble = _dbContext.Set<T>().AsQueryable();

        if(filter?.Count() > 0)
            queryble = TextFilter_Strings<T>(queryble, filter);

        //var filterPropertyInfo = typeof(GetAllAddressFilter).GetProperties();
        //for (int i = 0; i < filterPropertyInfo.Length; i++)
        //{
        //    var predicate = CreateLamdaExpression<T>(filterPropertyInfo[i], filter!);
        //    queryble = queryble.Where(predicate);
        //}



        var skip = (paginationFilter!.PageNumber - 1) * paginationFilter!.PageSize;
        var response = await queryble
            .Skip(skip)
            .Take(paginationFilter.PageSize)
            .ToListAsync();
        return response;
    }

    ///TODO: Refactor this method, try to implement that without add lib
    IQueryable<T> TextFilter_Strings<T>(IQueryable<T> source, string term)
    {
        if (string.IsNullOrEmpty(term)) { return source; }

        var elementType = source.ElementType;

        // Get all the string property names on this specific type.
        var stringProperties =
            elementType.GetProperties()
                .Where(x => x.PropertyType == typeof(string))
                .ToArray();
        if (!stringProperties.Any()) { return source; }

        // Build the string expression
        string filterExpr = string.Join(
            " || ",
            stringProperties.Select(prp => $"{prp.Name}.Contains(@0)")
        );

        return source.Where(filterExpr, term);
    }

   
    //private Expression<Func<T, bool>> CreateLamdaExpression<T>(System.Reflection.PropertyInfo propertyInfo, string value)
    //{
    //    var parameterExpression = Expression.Parameter(typeof(T));
    //    var memberExpression = Expression.PropertyOrField(parameterExpression, propertyInfo.Name);

    //    var binaryExpression = Expression.Equal(memberExpression, Expression.Constant(value));

    //    var lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, parameterExpression);
    //    return lambda;
    //}


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

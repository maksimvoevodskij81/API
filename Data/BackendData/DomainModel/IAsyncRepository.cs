using BackendData.DomainModel;

namespace BackendData;

public interface IAsyncRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> ListAllAsync(GetAllAddressSortFilter sort = null, string? filter = null, PaginationFilter ? paginationFilter = null);

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}

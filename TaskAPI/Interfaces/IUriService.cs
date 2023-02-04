using TaskAPI.Contracts.V1.Requests.Query;

namespace TaskAPI.Interfaces
{
    public interface IUriService
    {
        Uri GetAddressUri(string addressId);
        Uri GetAllAddressesUri(PaginationQuery paginationQuery);
    }
}

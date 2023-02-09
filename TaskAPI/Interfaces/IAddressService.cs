using BackendData.DomainModel;
using TaskAPI.Contracts.V1.Requests;

namespace TaskAPI.Interfaces;

public interface IAddressService
{
	Task<Address> CreateAndSaveAddress(AddressCreateRequest address);
	Task<Address> GetAddressByIdAsync(int addressId);
    Task<IReadOnlyList<Address>> RetrieveAllAddress(GetAllSortFilter? sort = null, GetAllSearchFilter? filter = null,
    PaginationFilter? paginationFilter = null);

    Task<bool> UpdateAddressAsync(AddressUpdateRequest address, int addressId);
    Task<bool> DeleteAddressAsync(int addressId);
}

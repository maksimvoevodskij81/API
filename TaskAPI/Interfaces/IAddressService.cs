using TaskAPI.ApiModels;

namespace TaskAPI.Interfaces;

public interface IAddressService
{
	Task<AddressDto> CreateAndSave(AddressDto newAddress);

}

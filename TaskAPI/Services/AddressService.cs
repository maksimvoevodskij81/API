using BackendData;
using BackendData.DomainModel;
using TaskAPI.ApiModels;
using TaskAPI.Interfaces;

namespace TaskAPI.Services;

public class AddressService : IAddressService
{
	private readonly IAsyncRepository<Address> _addressRepository;

	public AddressService(IAsyncRepository<Address> addressRepository)
	{
		_addressRepository = addressRepository;
	}

	public async Task<AddressDto> CreateAndSave(AddressDto newAddress)
	{
		var address = new Address
		{
			Country= newAddress.Country,
			City=newAddress.City,
			Street=newAddress.Street,
			HouseNumber=newAddress.HouseNumber,
			ZipCode = newAddress.ZipCode
		};

		await _addressRepository.AddAsync(address);

		return new AddressDto
			(address.Id, address.Country!, address.City!, address.Street!, address.HouseNumber!.Value, address.ZipCode!);
	}
}

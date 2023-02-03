using BackendData;
using BackendData.DomainModel;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Contracts.V1.Responses;
using TaskAPI.Interfaces;

namespace TaskAPI.Services;

public class AddressService : IAddressService
{
	private readonly IAsyncRepository<Address> _addressRepository;

	public AddressService(IAsyncRepository<Address> addressRepository)
	{
		_addressRepository = addressRepository;
	}

	public async Task<AddressResponse> CreateAndSaveAddress(AddressCreateRequest newAddress)
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
		return new AddressResponse(address.Id, address.Country!, address.City!, address.Street!, address.HouseNumber!, address.ZipCode!);
	}

	public async Task<IReadOnlyList<Address>> RetrieveAllAddress()
	{
		var addresses = await _addressRepository.ListAllAsync();
		return addresses;
	}

	public async Task<Address> GetAddressByIdAsync(int id) 
	{
	  var address = await _addressRepository.GetByIdAsync(id);
		return address;
    }

	public async Task<bool> UpdateAddressAsync(AddressUpdateRequest addressRequest, int addressRequstId )
	{
		var addressForUpdate = await GetAddressByIdAsync(addressRequstId);
		if(addressForUpdate is null) 
			return false;
		addressForUpdate.Country = addressRequest.Country;
		addressForUpdate.City = addressRequest.City;
		addressForUpdate.Street = addressRequest.Street;
		addressForUpdate.HouseNumber = addressRequest.HouseNumber;
		addressForUpdate.ZipCode = addressRequest.ZipCode;
		_addressRepository.UpdateAsync(addressForUpdate);
		return true;
	}

    public async Task<bool> DeleteAddressAsync(int addressRequstId)
    {
        var addressForUpdate = await GetAddressByIdAsync(addressRequstId);
        if (addressForUpdate is null)
            return false;
        _addressRepository.DeleteAsync(addressForUpdate);
        return true;
    }
}

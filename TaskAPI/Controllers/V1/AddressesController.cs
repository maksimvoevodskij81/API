using BackendData.DataAccess.Config;
using BackendData.DomainModel;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Interfaces;

namespace TaskAPI.Controllers.V1
{
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService authorService)
        {
            _addressService = authorService;
        }

        [HttpGet(ApiRouts.Addresses.Get)]
        public async Task<IActionResult> GetAddressByIdAsync([FromRoute]int addressId ) 
        {
           var result = await _addressService.GetAddressByIdAsync(addressId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet(ApiRouts.Addresses.GetAll)]
        public async Task<IActionResult> GetAllAddressAsync() 
        {
            return Ok(await _addressService.RetrieveAllAddress());
        }

        [HttpPost(ApiRouts.Addresses.Create)]
        public ActionResult Create([FromBody] AddressCreateRequest addressRequest)
        {
            var addressResponse = _addressService.CreateAndSaveAddress(addressRequest);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRouts.Addresses.Get.Replace("{addressId}", addressResponse.Id.ToString()) ;
            return Created(locationUri, addressResponse);

        }

        [HttpPut(ApiRouts.Addresses.Update)]
        public async Task<IActionResult> UpdateAddressAsync([FromRoute] int addressId,
            [FromBody] AddressUpdateRequest addressUpdateRequest)
        {
            var result = await _addressService.UpdateAddressAsync(addressUpdateRequest, addressId);
            if (!result)
                return NotFound();
            return NoContent();
        }
        [HttpDelete(ApiRouts.Addresses.Delete)]
        public async Task<IActionResult> DeleteAddressAsync([FromRoute] int addressId) 
        {
            var result = await _addressService.DeleteAddressAsync(addressId);
            if (result)
                return NoContent();

            return NotFound();
        }

    }
}

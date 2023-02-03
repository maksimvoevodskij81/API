using BackendData.DataAccess.Config;
using BackendData.DomainModel;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Contracts.V1.Responses;
using TaskAPI.Interfaces;

namespace TaskAPI.Controllers.V1
{
    [Produces("application/json")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService authorService)
        {
            _addressService = authorService;
        }
        /// <summary>
        /// Retrieve Address by Id
        /// </summary>
        /// <remarks>
        /// ***Please type exist Id***
        /// </remarks>
        /// <response code="200">Retrieve Address by Id</response>
        /// <response code="404">Address not found</response>
        [HttpGet(ApiRouts.Addresses.Get)]
        public async Task<IActionResult> GetAddressByIdAsync([FromRoute] int addressId)
        {
            var result = await _addressService.GetAddressByIdAsync(addressId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// Retreive all Addresses from database
        /// </summary>
        /// <response code="200">Retreive all Addresses from database</response>
        [HttpGet(ApiRouts.Addresses.GetAll)]
        public async Task<IActionResult> GetAllAddressAsync()
        {
            return Ok(await _addressService.RetrieveAllAddress());
        }
        /// <summary>
        /// Create an address in the system
        /// </summary>
        /// <remarks>
        /// ***Please fill in the form without space***
        /// </remarks>
        /// <response code="201">Create an address in the system</response>
        /// <response code="400">Unable to create the address due to validation error</response>

        [HttpPost(ApiRouts.Addresses.Create)]
        [ProducesResponseType(typeof(AddressCreateRequest), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]

        public ActionResult Create([FromBody] AddressCreateRequest addressRequest)
        {
            var addressResponse = _addressService.CreateAndSaveAddress(addressRequest);
            if (addressResponse is null)
                return BadRequest(new ErrorResponse{Errors = new List<ErrorModel> 
                { new ErrorModel { Message = "Unable to create address" } } });
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRouts.Addresses.Get.Replace("{addressId}", addressResponse.Id.ToString());
            return Created(locationUri, addressResponse);

        }
        /// <summary>
        /// Update the Address by Id
        /// </summary>
        /// <remarks>
        /// ***Please type exist Id***       
        /// 
        /// ***Please fill in the form without space***
        /// 
        /// </remarks>
        /// <response code="200">Operation Success</response>
        /// <response code="400">Operation Failed</response>

        [HttpPut(ApiRouts.Addresses.Update)]
        public async Task<IActionResult> UpdateAddressAsync([FromRoute] int addressId,
            [FromBody] AddressUpdateRequest addressUpdateRequest)
        {
            var result = await _addressService.UpdateAddressAsync(addressUpdateRequest, addressId);
            if (!result)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Delete the Address by Id
        /// </summary>
        /// <remarks>
        /// ***Please type exist Id***       
        /// </remarks>
        /// <response code="204">Operation Success</response>
        /// <response code="400">Operation Failed</response>
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

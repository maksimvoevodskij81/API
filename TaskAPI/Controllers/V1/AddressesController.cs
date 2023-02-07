using AutoMapper;
using BackendData.DomainModel;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Contracts.V1.Requests.Queries;
using TaskAPI.Contracts.V1.Requests.Query;
using TaskAPI.Contracts.V1.Responses;
using TaskAPI.Extansions;
using TaskAPI.Helpers;
using TaskAPI.Interfaces;

namespace TaskAPI.Controllers.V1
{
    [Produces("application/json")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public AddressesController(IAddressService authorService, IMapper mapper, IUriService uriService)
        {
            _addressService = authorService;
            _mapper = mapper;
            _uriService = uriService;
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
            var address = await _addressService.GetAddressByIdAsync(addressId);
            if (address is null)
                return NotFound();

            return Ok(new Response<AddressResponse>(_mapper.Map<AddressResponse>(address)));
        }


        /// <summary>
        /// Retreive all Addresses from database
        /// </summary>
        /// <response code="200">Retreive all Addresses from database</response>
        [HttpGet(ApiRouts.Addresses.GetAll)]
        public async Task<IActionResult> GetAllAddressAsync([FromQuery] GetAllAddressQuery query, 
            [FromQuery] PaginationQuery paginationQuery, [FromQuery] GetAllAddressSortQuery sortQuery)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery);
            
            var sortFilter = _mapper.Map<GetAllAddressSortFilter>(sortQuery);
            var addresses = await _addressService.RetrieveAllAddress(sortFilter, query.Search, paginationFilter);
            var addressResponse = _mapper.Map<List<AddressResponse>>(addresses);
            if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return Ok(new PageResponse<AddressResponse>(addressResponse));
            }
            var paginationResponse = PaginationHelper<AddressResponse>
                .CreatePaginatedResponse(_uriService, paginationFilter, addressResponse);
            return Ok(paginationResponse);
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
        public async Task<ActionResult> Create([FromBody] AddressCreateRequest addressRequest)
        {
            var address = await _addressService.CreateAndSaveAddress(addressRequest);
            if (address is null)
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                { new ErrorModel { Message = "Unable to create address" } }
                });

            var locationUri = _uriService.GetAddressUri(address.Id.ToString());
            return Created(locationUri, new Response<AddressResponse>(_mapper.Map<AddressResponse>(address)));
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

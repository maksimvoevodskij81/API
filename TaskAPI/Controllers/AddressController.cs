using Microsoft.AspNetCore.Mvc;
using TaskAPI.ApiModels;
using TaskAPI.Interfaces;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService authorService)
        {
            _addressService = authorService;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddressDto))]
        public async Task<ActionResult<AddressDto>> Create(AddressDto newAuthor)
        {
            var createdAddressDto =  await _addressService.CreateAndSave(newAuthor);
            return Created($"authors/{createdAddressDto.Id}", createdAddressDto);
        }
    }
}

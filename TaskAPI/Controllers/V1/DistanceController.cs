using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Contracts.V1.Requests.Queries;
using TaskAPI.Contracts.V1.Responses;
using TaskAPI.Options;
using TaskAPI.Services;

namespace TaskAPI.Controllers.V1
{
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DistanceController : ControllerBase
    {
        private readonly GoogleMapSettings _googleMapSettings;
        public DistanceController(IOptions<GoogleMapSettings> config)
        {
           _googleMapSettings = config.Value; 
        }
        /// <summary>
        /// Calculate distance between waypoints
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Operation Success</response>
        /// <response code="400">Operation Failed</response>

        [ProducesResponseType(typeof(AddressCreateRequest), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpGet(ApiRouts.Values.Index)]
        public async Task<IActionResult> Index([FromQuery] DistanceCalculateQuery distanceCalculateQuery)
        {
            GoogleDistanceMatrixApi api = new GoogleDistanceMatrixApi(new[] { distanceCalculateQuery.OriginAddresses },
                new[] { distanceCalculateQuery.DestinationAddresses }, _googleMapSettings);
            var response = await api.GetResponse();
            return Ok(response);
        }
    }
}

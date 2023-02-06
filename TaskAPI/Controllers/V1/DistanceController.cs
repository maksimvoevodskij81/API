using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Contracts.V1.Requests.Queries;
using TaskAPI.Contracts.V1.Responses;
using TaskAPI.Services;

namespace TaskAPI.Controllers.V1
{
    [Produces("application/json")]
    public class DistanceController : ControllerBase
    {

        /// <summary>
        /// Calculate distance between waypoints
        /// </summary>
        /// <remarks>
        /// ***Please fill in the form without space***
        /// </remarks>
        /// <response code="200">Operation Success</response>
        /// <response code="400">Operation Failed</response>

        [ProducesResponseType(typeof(AddressCreateRequest), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpGet(ApiRouts.Values.Index)]
        public async Task<IActionResult> Index([FromQuery] DistanceCalculateQuery distanceCalculateQuery)
        {
            GoogleDistanceMatrixApi api = new GoogleDistanceMatrixApi(new[] { distanceCalculateQuery.OriginAddresses }, new[] { distanceCalculateQuery.DestinationAddresses});
            var response = await api.GetResponse();
            return Ok(response);
        }
    }
}

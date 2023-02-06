using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests.Queries;
using TaskAPI.Services;

namespace TaskAPI.Controllers.V1
{
    public class DistanceController : ControllerBase
    {
        [HttpGet(ApiRouts.Values.Index)]
        public async Task<IActionResult> Index([FromQuery] DistanceCalculateQuery distanceCalculateQuery)
        {
            GoogleDistanceMatrixApi api = new GoogleDistanceMatrixApi(new[] { distanceCalculateQuery.OriginAddresses }, new[] { distanceCalculateQuery.DestinationAddresses});
            var response = await api.GetResponse();
            return Ok(response);
        }
    }
}

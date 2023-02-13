using Microsoft.AspNetCore.Mvc;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Contracts.V1.Responses;
using TaskAPI.Interfaces;

namespace TaskAPI.Controllers.V1
{
    [Produces("application/json")]

    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// Create a user in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <response code="201">Create a user in the system</response>
        /// <response code="400">Unable to create the user due to validation error</response>
        [ProducesResponseType(typeof(UserRegistrationRequest), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]

        [HttpPost(ApiRouts.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request) 
        {
            var registrationResult = await   _identityService.RegisterAsync(request.Email, request.Password);
            if (!registrationResult.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = registrationResult.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token= registrationResult.Token,
            });
        }

        /// <summary>
        /// Login a exist user in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <response code="200">Login exist user in the system</response>
        /// <response code="400">Unable to login the user due to validation error</response>
        [ProducesResponseType(typeof(UserLoginRequest), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpPost(ApiRouts.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var registrationResult = await _identityService.LoginAsync(request.Email, request.Password);
            if (!registrationResult.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = registrationResult.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = registrationResult.Token,
            });
        }
    }
}

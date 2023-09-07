using LocationTracker.Data.Contracts;
using LocationTracker.Data.Repository;
using LocationTracker.Dto;
using LocationTracker.Hubs;
using LocationTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LocationTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IGeoCoordinateRepository _repository;
        private readonly IHubContext<SignalRHub, ILocationHub> _hubContext;
        public HomeController(IGeoCoordinateRepository repository, IHubContext<SignalRHub, ILocationHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }


        [HttpPost]
        public async Task<ActionResult<Location>> GetLocation([FromBody] DistanceRequestDto requestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var distanceResult = await _repository.CalculateDistance(requestDto);
                if (distanceResult >= 20)
                {
                   var result =  await _hubContext.Clients.All.ReceiveNewLocation(requestDto.SecondPointLatitude, requestDto.SecondPointLongitude);
                   return Ok(result);                        
                }

                return new Location { Latitude = requestDto.FirstPointLatitude, Longitude = requestDto.FirstPointLongitude };
            }
            catch (Exception ex)
            {

                new Exception(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }
    }
}

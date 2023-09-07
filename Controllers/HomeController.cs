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
        private readonly IHubContext<LocationHub, ILocationHub> _hubContext;
        public HomeController(IGeoCoordinateRepository repository, IHubContext<LocationHub, ILocationHub> hubContext)
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
                    await _hubContext.Clients.All.ReceiveNewLocation(requestDto.SecondPointLatitude, requestDto.SecondPointLongitude);
                    return new Location { Latitude = requestDto.SecondPointLatitude, Longitude = requestDto.SecondPointLongitude };
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

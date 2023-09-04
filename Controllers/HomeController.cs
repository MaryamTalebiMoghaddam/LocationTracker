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
        private readonly IHubContext<LocationHub> _hubContext;
        public HomeController(IGeoCoordinateRepository repository,  IHubContext<LocationHub> hubContext)
        {            
            _repository = repository;
            _hubContext = hubContext;
        }


        [HttpPost]
        public async Task<ActionResult<double>> GetDistance([FromBody] DistanceRequestDto requestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _repository.CalculateDistance(requestDto);
                if (result >= 20)
                {                    
                    await _hubContext.Clients.All.SendAsync("UpdateLocation", requestDto.SecondPointLatitude, requestDto.SecondPointLongitude);
                }

                return result;
            }
            catch (Exception ex)
            {

                new Exception(ex.Message);              
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }
    }
}

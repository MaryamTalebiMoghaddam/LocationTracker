
using LocationTracker.Model;
using Microsoft.AspNetCore.SignalR;
namespace LocationTracker.Hubs
{
    public class LocationHub : Hub<ILocationHub>
    {
        private readonly ILocationHub _locationHubClient;

        public LocationHub(ILocationHub locationHubClient)
        {
            _locationHubClient = locationHubClient;
        }

        public async Task UpdateLocation(double latitude, double longitude)
        {
            
            await _locationHubClient.ReceiveNewLocation(latitude, longitude);
            
        }

    }
}

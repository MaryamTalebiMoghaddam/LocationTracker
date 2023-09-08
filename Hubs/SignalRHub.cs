
using LocationTracker.Model;
using Microsoft.AspNetCore.SignalR;
namespace LocationTracker.Hubs
{
    public class SignalRHub : Hub<ILocationHub>
    {
        //private readonly ILocationHub _locationHubClient;

        //public SignalRHub(ILocationHub locationHubClient)
        //{
        //    _locationHubClient = locationHubClient;
        //}

        public async Task UpdateLocation(double latitude, double longitude)
        {
            
            await Clients.Caller.ReceiveNewLocation(latitude, longitude);
            
        }

    }
}

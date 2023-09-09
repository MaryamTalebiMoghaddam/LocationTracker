
using LocationTracker.Model;
using Microsoft.AspNetCore.SignalR;
namespace LocationTracker.Hubs
{
    public class SignalRHub : Hub<ILocationHub>
    {
        private readonly ILocationHub _locationHubClient;

        public SignalRHub(ILocationHub locationHubClient)
        {
            _locationHubClient = locationHubClient;
        }

        public async Task UpdateLocation(string latitude, string longitude)
        {                      
             await Clients.All.ReceiveNewLocation(latitude, longitude);

        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}


using Microsoft.AspNetCore.SignalR;
namespace LocationTracker.Hubs
{
    public class LocationHub : Hub
    {
        public async Task UpdateLocation(double latitude, double longitude)
        {
            await Clients.All.SendAsync("ReceiveNewLocation", latitude, longitude);
        }
    }
}

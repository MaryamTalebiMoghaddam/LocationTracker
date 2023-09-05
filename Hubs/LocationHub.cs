
using Microsoft.AspNetCore.SignalR;
namespace LocationTracker.Hubs
{
    public class LocationHub : Hub<ILocationHub>
    {
        
        public async Task UpdateLocation(double latitude, double longitude)
        {
            await Clients.All.ReceiveNewLocation(latitude, longitude);
        }
         
    }
}

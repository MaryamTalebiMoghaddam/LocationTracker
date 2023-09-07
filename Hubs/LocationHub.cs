using LocationTracker.Model;

namespace LocationTracker.Hubs
{
    public class LocationHub : ILocationHub
    {
        public async Task<Location> ReceiveNewLocation(double SecondPointLatitude, double SecondPointLongitude)
        {
             return new Location { Latitude = SecondPointLatitude, Longitude = SecondPointLongitude };
        }
    }
}

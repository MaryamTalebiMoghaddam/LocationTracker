using LocationTracker.Model;

namespace LocationTracker.Hubs
{
    public class LocationHub : ILocationHub
    {
        public Task ReceiveNewLocation(string SecondPointLatitude, string SecondPointLongitude)
        {
            var secondLat = Convert.ToDouble(SecondPointLatitude);
            var secondLon = Convert.ToDouble(SecondPointLongitude);
            new Location { Latitude = secondLat, Longitude = secondLon };
            return Task.CompletedTask;
        }
    }
}

using LocationTracker.Model;

namespace LocationTracker.Hubs
{
    public interface ILocationHub
    {
        Task<Location> ReceiveNewLocation(double SecondPointLatitude, double SecondPointLongitude);
    }
}

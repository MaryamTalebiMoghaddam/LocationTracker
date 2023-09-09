using LocationTracker.Model;

namespace LocationTracker.Hubs
{
    public interface ILocationHub
    {
        Task ReceiveNewLocation(string SecondPointLatitude, string SecondPointLongitude);
    }
}

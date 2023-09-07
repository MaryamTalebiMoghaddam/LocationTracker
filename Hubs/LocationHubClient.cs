﻿using LocationTracker.Model;

namespace LocationTracker.Hubs
{
    public class LocationHubClient : ILocationHub
    {
        public async Task ReceiveNewLocation(double SecondPointLatitude, double SecondPointLongitude)
        {
             new Location { Latitude = SecondPointLatitude, Longitude = SecondPointLongitude };
        }
    }
}
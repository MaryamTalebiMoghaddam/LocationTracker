
using LocationTracker.Data.Contracts;
using LocationTracker.Dto;
using LocationTracker.Model;

namespace LocationTracker.Data.Repository
{
    public class GeoCoordinateRepository : IGeoCoordinateRepository
    {
        public GeoCoordinateRepository()
        {

        }
        public async Task<double> CalculateDistance(DistanceRequestDto requestDto)
        {
            var x1 = requestDto.FirstPointLatitude * (Math.PI / 180.0);
            var y1 = requestDto.FirstPointLongitude * (Math.PI / 180.0);
            var x2 =requestDto.SecondPointLatitude * (Math.PI / 180.0);
            var y2 = requestDto.SecondPointLongitude * (Math.PI / 180.0) - y1;
            var d3 = Math.Pow(Math.Sin((x2 - x1) / 2.0), 2.0) +
                     Math.Cos(x1) * Math.Cos(x2) * Math.Pow(Math.Sin(y2 / 2.0), 2.0);
            var result = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
            await Task.CompletedTask;
            return result;
        }

    }
}

using LocationTracker.Dto;
using LocationTracker.Model;

namespace LocationTracker.Data.Contracts
{
    public interface IGeoCoordinateRepository
    {
        Task<double> CalculateDistance(DistanceRequestDto requestDto);
    }
}

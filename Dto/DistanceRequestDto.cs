using LocationTracker.Model;
using System.ComponentModel.DataAnnotations;

namespace LocationTracker.Dto
{
    public class DistanceRequestDto
    {
        [Required]
        [Range(-90, 90)]

        public double FirstPointLatitude { get; set; } = 0;


        [Required]
        [Range(-180, 180)]
        public double FirstPointLongitude { get; set; } = 0;


        [Required]
        [Range(-90, 90)]
        public double SecondPointLatitude { get; set; } = 0;


        [Required]
        [Range(-180, 180)]
        public double SecondPointLongitude { get; set; } = 0;
    }
}

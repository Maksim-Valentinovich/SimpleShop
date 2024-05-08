using SimpleShop.Application.Common;

namespace SimpleShop.Application.Cities.Dto
{
    public class CityDto : EntityDto
    {
        public required string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}

using SimpleShop.Application.Cities.Dto;

namespace SimpleShop.Application.Cities
{
    public interface ICityAppService : IApplicationService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();

        Task<CityDto> GetAsync(double Latitude, double Longitude);
    }
}

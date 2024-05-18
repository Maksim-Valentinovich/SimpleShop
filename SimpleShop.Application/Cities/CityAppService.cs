using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Cities.Dto;
using SimpleShop.Domain;

namespace SimpleShop.Application.Cities
{
    public class CityAppService : SimpleShopAppService, ICityAppService
    {
        public CityAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var cities = await Context.Cities
                .ToListAsync();
            return Mapper.Map<IEnumerable<CityDto>>(cities);
        }

        public async Task<CityDto> GetAsync(double Latitude, double Longitude)
        {
            var city = await Context.Cities
                .Where(c => c.Latitude == Latitude && c.Longitude == Longitude)
                .FirstAsync();
            return Mapper.Map<CityDto>(city);
        }
    }
}

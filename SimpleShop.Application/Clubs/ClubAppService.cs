using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Domain;

namespace SimpleShop.Application.Clubs
{
    public class ClubAppService : SimpleShopAppService, IClubAppService
    {
        public ClubAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<ClubDto>> GetAllAsync(int cityId)
        {
            var clubs = await Context.Clubs
                .Include(c => c.City)
                .Where(c => c.CityId == cityId)
                .ProjectTo<ClubDto>(Mapper.ConfigurationProvider)
                .ToListAsync();

            return clubs;
        }
    }

}

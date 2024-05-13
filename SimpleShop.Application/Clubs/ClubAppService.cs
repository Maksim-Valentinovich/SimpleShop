using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clubs;

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

        public async Task<IEnumerable<ClubDto>> GetAllAsync(string clubName)
        {
            var clubs = await Context.Clubs
                .Include(c => c.City)
                .Where(c => c.Name == clubName)
                .ProjectTo<ClubDto>(Mapper.ConfigurationProvider)
                .ToListAsync();

            return clubs;
        }

        public async Task<ClubProduct[]> GetClubsFromProductAsync(int productId)
        {
            var clubs = await Context.ClubProducts
                .Where(c => c.ProductId == productId)
                .Include(c => c.Club)
                .ToArrayAsync();

            return clubs;
        }

        public async Task<ClubDto> GetAsync(int clubId)
        {
            var club = await Context.Clubs
                .Include(c => c.City)
                .Where(c => c.Id == clubId)
                .ProjectTo<ClubDto>(Mapper.ConfigurationProvider)
                .FirstAsync();

            return club;
        }
    }

}

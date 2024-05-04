using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Coaches.Dto;
using SimpleShop.Domain;

namespace SimpleShop.Application.Coaches
{
    public class CoachAppService : SimpleShopAppService, ICoachAppService
    {
        public CoachAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<CoachDto>> GetAllAsync(int clubId)
        {
            var coaches = await Context.Coaches
                .Include(c => c.Club)
                .Where(c => c.ClubId == clubId)
                .ProjectTo<CoachDto>(Mapper.ConfigurationProvider)
                .ToListAsync();

            return coaches;
        }
    }
}

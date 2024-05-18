using AutoMapper;
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
                .ToListAsync();

            return (Mapper.Map<IEnumerable<CoachDto>>(coaches));

        }

        public async Task<CoachDto> GetAsync(int coachId)
        {
            var coach = await Context.Coaches
                .Include(c => c.Club)
                .FirstAsync(c => c.Id == coachId);

            return Mapper.Map<CoachDto>(coach);
        }
    }
}

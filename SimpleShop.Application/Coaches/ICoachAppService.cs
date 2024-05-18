using SimpleShop.Application.Coaches.Dto;

namespace SimpleShop.Application.Coaches
{
    public interface ICoachAppService : IApplicationService
    {
        Task<IEnumerable<CoachDto>> GetAllAsync(int clubId);

        Task<CoachDto> GetAsync(int coachId);
    }
}

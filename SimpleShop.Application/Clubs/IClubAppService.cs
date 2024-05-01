using SimpleShop.Application.Clubs.Dto;

namespace SimpleShop.Application.Clubs
{
    public interface IClubAppService : IApplicationService
    {
        Task<IEnumerable<ClubDto>> GetAllAsync(int cityId);
    }
}

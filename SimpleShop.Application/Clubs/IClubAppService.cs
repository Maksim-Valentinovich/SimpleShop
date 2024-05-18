using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Domain.Entities.Clubs;

namespace SimpleShop.Application.Clubs
{
    public interface IClubAppService : IApplicationService
    {
        Task<IEnumerable<ClubDto>> GetAllAsync(int cityId);

        Task<IEnumerable<ClubDto>> GetAllAsync(string clubName);

        Task<ClubProduct[]> GetClubsFromProductAsync(int productId);

        Task<ClubDto> GetAsync(int clubId);
    }
}

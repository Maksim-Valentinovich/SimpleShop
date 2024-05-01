using SimpleShop.Application.Clients.Dto;
using SimpleShop.Application.Clubs.Dto;

namespace SimpleShop.Application.Clients
{
    public interface IClientAppService : IApplicationService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync(int cityId);
    }
}

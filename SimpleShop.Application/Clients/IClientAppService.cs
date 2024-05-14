using SimpleShop.Application.Clients.Dto;

namespace SimpleShop.Application.Clients
{
    public interface IClientAppService : IApplicationService
    {
        Task<ClientDto> GetAsync(string email);
        Task<ClientDto> GetAsync(string email, string password);
        Task<ClientDto> GetAsync(int clientId);
        int GetLast();
        Task AddAsync(ClientDto clientDto);
    }
}

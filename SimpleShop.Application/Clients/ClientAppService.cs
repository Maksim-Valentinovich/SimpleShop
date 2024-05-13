using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clients;

namespace SimpleShop.Application.Clients
{
    public class ClientAppService : SimpleShopAppService, IClientAppService
    {
        public ClientAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ClientDto> GetAsync(string email)
        {
            var client = await Context.Clients
                .FirstOrDefaultAsync(c => c.Email == email);

            return Mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> GetAsync(int clientId)
        {
            var client = await Context.Clients
                .FirstOrDefaultAsync(c => c.Id == clientId);

            return Mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> GetAsync(string email, string password)
        {
            var client = await Context.Clients
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            return Mapper.Map<ClientDto>(client);
        }

        public async Task AddAsync(ClientDto clientDto)
        {
            var client = Mapper.Map<Client>(clientDto);

            await Context.Clients.AddAsync(client);
            await Context.SaveChangesAsync();

        }
    }
}

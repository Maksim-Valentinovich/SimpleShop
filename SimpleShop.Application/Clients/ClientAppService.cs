using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Domain;

namespace SimpleShop.Application.Clients
{
    public class ClientAppService : SimpleShopAppService, IClientAppService
    {
        public ClientAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<IEnumerable<ClientDto>> GetAllAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public async Task<ClientDto> GetAsync(int id)
        {
            var client = await Context.Clients.FirstAsync(c => c.Id == id);
            ClientDto clientdto = new()
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Patronymic = client.Patronymic,
                Email = client.Email,
                Birhday = client.Birhday,
                Phone = client.Phone,
                IsMan = client.IsMan,
                Password = client.Password,
            };

            return clientdto;
        }
    }
}

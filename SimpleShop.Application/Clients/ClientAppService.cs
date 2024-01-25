using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Application.Clients
{
    public class ClientAppService : SimpleShopAppService, IClientAppService
    {
        public ClientAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ClientDto> GetAsync(int id)
        {
            var client = await Context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            return null;
        }
    }
}

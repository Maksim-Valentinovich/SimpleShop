using SimpleShop.Application.Clients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Application.Clients
{
    public interface IClientAppService
    {
        Task<ClientDto> GetAsync(int id);
    }
}

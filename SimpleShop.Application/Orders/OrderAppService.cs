using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Orders.Dto;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clients;
using SimpleShop.Domain.Entities.Orders;

namespace SimpleShop.Application.Orders
{
    public class OrderAppService : SimpleShopAppService, IOrderAppService
    {
        public OrderAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task AddAsync(OrderDto orderDto, int clientId = 0)
        {
            Order order = new()
            {
                ClientId = clientId == 0 ? (orderDto.ClientId) : (clientId),
                Date = DateTime.Now,
                IsOnline = orderDto.IsOnline,
                Sum = orderDto.Sum,
            };
            //var order = Mapper.Map<Order>(orderDto);
            await Context.Orders.AddAsync(order);
            await Context.SaveChangesAsync();
        }

        public async Task<OrderDto> GetLast()
        {
            var order = await Context.Orders.OrderBy(c => c.Id).LastAsync();
            return Mapper.Map<OrderDto>(order);
        }

        public IEnumerable<OrderDto> GetOrder(int clientId)
        {
            var order = Context.Orders.Where(x => x.ClientId == clientId).ToListAsync();
            return Mapper.Map<IEnumerable<OrderDto>>(order);
        }
    }
}

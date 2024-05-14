using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Orders.Dto;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Orders;

namespace SimpleShop.Application.Orders
{
    public class OrderAppService : SimpleShopAppService, IOrderAppService
    {
        public OrderAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task AddAsync(OrderDto orderDto)
        {
            Order order = new()
            {
                ClientId = orderDto.ClientId,
                Date = orderDto.Date,
                IsOnline = orderDto.IsOnline,
                Sum = orderDto.Sum,
            };
            //var order = Mapper.Map<Order>(orderDto);
            await Context.Orders.AddAsync(order);
            await Context.SaveChangesAsync();
        }

        public async Task AddAsync(OrderDto orderDto, int clientId)
        {
            Order order = new()
            {
                ClientId = clientId,
                Date = orderDto.Date,
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
    }
}

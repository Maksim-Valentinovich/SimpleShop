using SimpleShop.Application.Orders.Dto;

namespace SimpleShop.Application.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task AddAsync(OrderDto orderDto, int clientId);
        Task AddAsync(OrderDto orderDto);
        Task<OrderDto> GetLast();
    }
}

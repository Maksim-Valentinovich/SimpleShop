using SimpleShop.Application.Orders.Dto;

namespace SimpleShop.Application.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task AddAsync(OrderDto orderDto, int clientId = 0);
        Task<OrderDto> GetLast();
        IEnumerable<OrderDto> GetOrder(int clientId);
    }
}

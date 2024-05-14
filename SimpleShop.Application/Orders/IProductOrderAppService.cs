using SimpleShop.Application.Orders.Dto;

namespace SimpleShop.Application.Orders
{
    public interface IProductOrderAppService : IApplicationService
    {
        Task AddAsync(ProductOrderDto productOrderDto);
    }
}

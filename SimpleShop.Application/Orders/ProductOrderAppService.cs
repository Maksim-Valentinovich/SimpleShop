using AutoMapper;
using SimpleShop.Application.Orders.Dto;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Orders;

namespace SimpleShop.Application.Orders
{
    public class ProductOrderAppService : SimpleShopAppService, IProductOrderAppService
    {
        public ProductOrderAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task AddAsync(ProductOrderDto productOrderDto)
        {
            await Context.Subscriptions.AddAsync(Mapper.Map<ProductOrder>(productOrderDto));
        }
    }
}

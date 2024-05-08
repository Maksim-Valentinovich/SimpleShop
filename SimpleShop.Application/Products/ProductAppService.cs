using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Products.Dto;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clubs;

namespace SimpleShop.Application.Products
{
    internal class ProductAppService : SimpleShopAppService, IProductAppService
    {
        public ProductAppService(SimpleShopContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<ProductDto> GetAsync(int productId)
        {
            var category = await Context.CategoryProducts
                .Where(c => c.ProductId == productId)
                .Include(c => c.Category)
                .Include(c => c.Product)
                .FirstAsync();

            return Mapper.Map<ProductDto>(category);
        }
    }
}

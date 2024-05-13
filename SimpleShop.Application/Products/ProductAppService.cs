using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Products.Dto;
using SimpleShop.Domain;

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

        public async Task<IEnumerable<ProductDto>> GetAllAsync(int categoryId)
        {
            var products = await Context.CategoryProducts
                .Where(c => c.CategoryId == categoryId)
                .Include(c => c.Product)
                .Include(c => c.Category)
                .ToArrayAsync();

            return Mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}

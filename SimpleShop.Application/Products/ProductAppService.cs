using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Products.Dto;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Orders;
using SimpleShop.Domain.Entities.Products;

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

        public List<ProductDto> GetProductAllAsync(int categoryId)
        {
            var products = Context.CategoryProducts
                .Where(c => c.CategoryId == categoryId)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToArrayAsync();

            return Mapper.Map<List<ProductDto>>(products);
        }

        public List<ProductDto> GetProductOrder(int orderId)
        {
            var products =  Context.Subscriptions
                 .Where(x => x.OrderId == orderId)
                 .Include(c => c.Product)
                 .Select(c => c.Product)
                 .ToListAsync();

            return Mapper.Map<List<ProductDto>>(products);
        }
    }
}

using SimpleShop.Application.Products.Dto;

namespace SimpleShop.Application.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> GetAsync(int productId);
    }
}

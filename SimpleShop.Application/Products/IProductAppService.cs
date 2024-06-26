﻿using SimpleShop.Application.Products.Dto;

namespace SimpleShop.Application.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> GetAsync(int productId);
        Task<IEnumerable<ProductDto>> GetAllAsync(int categoryId);

        List<ProductDto> GetProductAllAsync(int categoryId);

        List<ProductDto> GetProductOrder(int orderId);
    }
}

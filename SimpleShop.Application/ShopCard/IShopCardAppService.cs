namespace SimpleShop.Application.ShopCard
{
    public interface IShopCardAppService : IApplicationService
    {
        Task AddToCard(int productId, int clubId);
    }
}

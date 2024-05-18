using SimpleShop.Application.ShopCard.Dto;

namespace SimpleShop.Application.ShopCard
{
    public interface IShopCardAppService : IApplicationService
    {
        Task AddProduct(int productId, int clubId);

        void DeleteProduct(int index);

        public ShopCardDto GetShopItems();

        public ShopCardDto GetShopClubs();

        public string ShopCardSession();
    }
}

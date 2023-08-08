using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(int id);

    }
}

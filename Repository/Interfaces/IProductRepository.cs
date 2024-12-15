using Sticker_Web_dotnet.Models;

namespace Sticker_Web_dotnet.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task UpdateAsync(Product obj);
    }
}

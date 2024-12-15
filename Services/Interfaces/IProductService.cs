using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Models.ViewModels;

namespace Sticker_Web_dotnet.Services.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(Product obj);
        Task<IEnumerable<Product>> GetAllAsync(string include);
        Task<Product> GetAsync(int? id);
        ProductVM ImageHandle(ProductVM productVM, IFormFile? file);
        Task RemoveAsync(Product obj);
        Task UpdateAsync(Product obj);
    }
}

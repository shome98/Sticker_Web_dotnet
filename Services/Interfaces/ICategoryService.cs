using Sticker_Web_dotnet.Models;

namespace Sticker_Web_dotnet.Services.Interfaces
{
    public interface ICategoryService
    {
        Task AddAsync(Category obj);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetAsync(int id);
        Task RemoveAsync(Category obj);
        Task UpdateAsync(Category obj);
    }
}

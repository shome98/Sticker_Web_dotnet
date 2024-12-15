using Sticker_Web_dotnet.Models;

namespace Sticker_Web_dotnet.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task UpdateAsync(Category obj);
    }
}

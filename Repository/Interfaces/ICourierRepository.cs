using Sticker_Web_dotnet.Models;

namespace Sticker_Web_dotnet.Repository.Interfaces
{
    public interface ICourierRepository : IRepository<Courier>
    {
        Task UpdateAsync(Courier obj);
    }
}

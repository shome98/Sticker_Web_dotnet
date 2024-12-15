using Sticker_Web_dotnet.Models;

namespace Sticker_Web_dotnet.Repository.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task UpdateAsync(Vendor obj);
    }
}

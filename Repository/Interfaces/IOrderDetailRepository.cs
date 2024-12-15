using Sticker_Web_dotnet.Models;

namespace Sticker_Web_dotnet.Repository.Interfaces
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        Task UpdateAsync(OrderDetail obj);
    }
}

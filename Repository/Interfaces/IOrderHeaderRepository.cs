using Sticker_Web_dotnet.Models;

namespace Sticker_Web_dotnet.Repository.Interfaces
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        Task UpdateAsync(OrderHeader obj);
        Task UpdateStatusAsync(int id, string orderStatus, string? paymentStatus = null);
        Task UpdateStripePaymentIdAsync(int id, string sessionId, string paymentIntentId);
    }
}

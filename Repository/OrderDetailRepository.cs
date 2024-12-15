using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Data;
using Sticker_Web_dotnet.Repository.Interfaces;

namespace Sticker_Web_dotnet.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}

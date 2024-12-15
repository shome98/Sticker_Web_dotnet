using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Data;
using Sticker_Web_dotnet.Repository.Interfaces;

namespace Sticker_Web_dotnet.Repository
{
    public class CourierRepository : Repository<Courier>, ICourierRepository
    {
        private readonly ApplicationDbContext _db;
        public CourierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Courier obj)
        {
            _db.Couriers.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}

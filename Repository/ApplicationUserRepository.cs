using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Data;
using Sticker_Web_dotnet.Repository;
using Sticker_Web_dotnet.Repository.Interfaces;

namespace Sticker_Web_dotnet.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}

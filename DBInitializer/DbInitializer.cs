using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sticker_Web_dotnet.Data;
using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Utility;

namespace Sticker_Web_dotnet.DBInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbInitializer(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager,ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async void Initialize()
        {
            try
            {
                if ((await _db.Database.GetPendingMigrationsAsync()).Count() > 0)
                {
                    await _db.Database.MigrateAsync();
                }
            }
            catch (Exception ex) { }
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Vendor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Courier)).GetAwaiter().GetResult();


                //if roles are not created, then we will create admin user as well
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "adminSticker",
                    Email = "adminsticker@gmail.com",
                    Name = "Admin Sticker",
                    PhoneNumber = "9876543210",
                    StreetAddress = "123 Admin Street Address",
                    State = "Admin State",
                    PostalCode = "987654",
                    City = "Admin City"
                }, "Admin123*").GetAwaiter().GetResult();


                ApplicationUser user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == "adminsticker@gmail.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }
            return;
            //throw new NotImplementedException();
        }
    }
}

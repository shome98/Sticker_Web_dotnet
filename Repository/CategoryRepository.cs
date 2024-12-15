﻿using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Data;
using Sticker_Web_dotnet.Repository.Interfaces;

namespace Sticker_Web_dotnet.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Category obj)
        {
            _db.Categories.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}

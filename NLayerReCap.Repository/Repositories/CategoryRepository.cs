using Microsoft.EntityFrameworkCore;
using NLayerReCap.Core.Models;
using NLayerReCap.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithProductsAsync(int id)
        {
            return await _dbSet.Include(x => x.Products).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}

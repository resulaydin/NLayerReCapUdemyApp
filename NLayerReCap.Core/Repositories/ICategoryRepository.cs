using NLayerReCap.Core.Models;
using NLayerReCap.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Core.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category> 
    {
        Task<Category> GetCategoryByIdWithProductsAsync(int id);
    }
}

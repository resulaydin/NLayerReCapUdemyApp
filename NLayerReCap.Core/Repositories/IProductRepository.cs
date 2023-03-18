using NLayerReCap.Core.Dtos;
using NLayerReCap.Core.Models;
using NLayerReCap.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Core.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        // Dikkat : Core ve Repository katmanında geriye normal entity gönder
        Task<List<Product>> GetProductsWithCategoryAsync();

    }
}

using NLayerReCap.Core.Dtos;
using NLayerReCap.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<CustomResponseDto<CategoryByIdWithProducts>> GetCategoryByIdWithProductsAsync(int id);
    }
}

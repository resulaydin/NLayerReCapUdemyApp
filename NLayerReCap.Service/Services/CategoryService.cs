using AutoMapper;
using NLayerReCap.Core.Dtos;
using NLayerReCap.Core.Models;
using NLayerReCap.Core.Repositories;
using NLayerReCap.Core.Repository;
using NLayerReCap.Core.Services;
using NLayerReCap.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Service.Services
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryByIdWithProducts>> GetCategoryByIdWithProductsAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProductsAsync(id);
            var categoryWithProductsDto=_mapper.Map<CategoryByIdWithProducts>(category);
            return CustomResponseDto<CategoryByIdWithProducts>.Success(200,categoryWithProductsDto);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerReCap.Core.Dtos;
using NLayerReCap.Core.Models;
using NLayerReCap.Core.Services;

namespace NLayerReCap.API.Controllers
{

    public class CategorysController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategorysController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int id)
        {
            var categoryByIdWithProductsDto = await _categoryService.GetCategoryByIdWithProductsAsync(id);
            return CreateActionResult( categoryByIdWithProductsDto);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDto=_mapper.Map<List<CategoryDto>>(categories);
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200,categoryDto)) ;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200,categoryDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {            
            var categoy = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var categorySavedDto = _mapper.Map<CategoryDto>(categoy);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201,categorySavedDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}

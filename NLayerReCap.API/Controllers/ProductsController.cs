using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerReCap.Core.Dtos;
using NLayerReCap.Core.Models;
using NLayerReCap.Core.Services;

namespace NLayerReCap.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        //private readonly IService<Product> _service;
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            var productsWithCategory = await _service.GetProductsWithCategoryAsync();
            return CreateActionResult(productsWithCategory);
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products=await _service.GetAllAsync();
            var productsDto=_mapper.Map<List<ProductDto>>(products);
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product= await _service.GetByIdAsync(id);
            var productDto=_mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productDtoSaved = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDtoSaved));// 201 created istek basarili
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _service.Update(_mapper.Map<Product>(productUpdateDto));
            return CreateActionResult(CustomResponseDto<ProductUpdateDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<Product>.Success(204));// Geriye değer dönmeyeceğimiz için 204 yazılmaktadır.
        }
    }
}

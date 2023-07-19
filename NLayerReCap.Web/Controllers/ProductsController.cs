using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerReCap.Core.Dtos;
using NLayerReCap.Core.Models;
using NLayerReCap.Core.Services;

namespace NLayerReCap.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View((await _productService.GetProductsWithCategoryAsync()).Data);
        }

        public async Task<IActionResult> Save()
        {
            var categoryDtos = _mapper.Map<List<CategoryDto>>((await _categoryService.GetAllAsync()).ToList());
            ViewBag.Categories = new SelectList(categoryDtos, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }
            var categoryDtos = _mapper.Map<List<CategoryDto>>((await _categoryService.GetAllAsync()).ToList());
            ViewBag.Categories = new SelectList(categoryDtos, "Id", "Name");
            return View();
        }
    }
}

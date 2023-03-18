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
    public class ProductService : Service<Product>,IProductService
    {
        private readonly IProductRepository _productRepositor;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepositor, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepositor = productRepositor;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductsWithCategoryDto>>> GetProductsWithCategoryAsync()
        {
            var products= await _productRepositor.GetProductsWithCategoryAsync();
            var productsDto= _mapper.Map<List<ProductsWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductsWithCategoryDto>>.Success(200, productsDto) ;
        }
    }
}

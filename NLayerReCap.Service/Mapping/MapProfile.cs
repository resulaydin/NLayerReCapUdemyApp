using AutoMapper;
using NLayerReCap.Core.Dtos;
using NLayerReCap.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap(); // Burayı eklemeden AAA alanını çalıştırmak Not Mappin hatası veriyordu.
            CreateMap<Category, CategoryByIdWithProducts>();
            CreateMap<Product,ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductsWithCategoryDto>().ReverseMap(); // AAA
            
        }
    }
}

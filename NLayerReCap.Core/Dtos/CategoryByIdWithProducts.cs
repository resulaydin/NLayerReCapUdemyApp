using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Core.Dtos
{
    public class CategoryByIdWithProducts:CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}

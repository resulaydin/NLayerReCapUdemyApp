﻿using NLayerReCap.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Core.Dtos
{
    public class ProductsWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}

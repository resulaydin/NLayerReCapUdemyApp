using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerReCap.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, CategoryId = 1, Name = "Kalem 1", Stock = 20, Price = 25, CreatedDate = DateTime.Now },
                new Product() { Id = 2, CategoryId = 2, Name = "Defter 1", Stock = 50, Price = 540, CreatedDate = DateTime.Now },
                new Product() { Id = 3, CategoryId = 2, Name = "Defter 2", Stock = 350, Price = 50, CreatedDate = DateTime.Now },
                new Product() { Id = 4, CategoryId = 3, Name = "Silgi 1", Stock = 350, Price = 250, CreatedDate = DateTime.Now },
                new Product() { Id = 5, CategoryId = 1, Name = "Kalem 2", Stock = 380, Price = 150, CreatedDate = DateTime.Now }

                );
        }
    }
}

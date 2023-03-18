using Microsoft.EntityFrameworkCore;
using NLayerReCap.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerReCap.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ProductFeature>().HasData(
                    new ProductFeature() { Id=1,ProductId=1,Color="Green",Height=20,Width=40},
                    new ProductFeature() { Id=2,ProductId=4,Color="Yellow",Height=25,Width=80}
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}

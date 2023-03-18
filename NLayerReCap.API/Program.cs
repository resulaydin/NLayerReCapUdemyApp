
using Microsoft.EntityFrameworkCore;
using NLayerReCap.Core.Repositories;
using NLayerReCap.Core.Repository;
using NLayerReCap.Core.Services;
using NLayerReCap.Core.UnitOfWorks;
using NLayerReCap.Repository;
using NLayerReCap.Repository.Repositories;
using NLayerReCap.Repository.UnitOfWorks;
using NLayerReCap.Service.Mapping;
using NLayerReCap.Service.Services;
using System.Reflection;

namespace NLayerReCap.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region ilgili DI eklemelerimiz yapildi
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            #region AutoMapping Process 
            builder.Services.AddAutoMapper(typeof(MapProfile));
            #endregion

            #region AppDbContext - ConnectionString - Migration Process
            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
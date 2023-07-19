using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayerReCap.Repository;
using NLayerReCap.Service.Mapping;
using NLayerReCap.Service.Validations;
using NLayerReCap.Web.Modules;
using System.Reflection;

namespace NLayerReCap.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            #region Fluent Validationumuzun nerede oldugundan haberdar ettik (FILTERSIZ)			
            builder.Services.AddFluentValidationAutoValidation()
                            .AddFluentValidationClientsideAdapters()
                            .AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
            /* FluentValidation' unun IResult larinin bizim tasarladigimiz sekilde calisabilmesi icin 
               API' in default kullandigi FluentValidation IResult nesnesini Suppress yapacagim.Yani API' nin konfigurationuna
               mudahale edecegim
			*/
            //builder.Services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});
            #endregion

            #region Autofac uygulandi 
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(
                containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
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
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
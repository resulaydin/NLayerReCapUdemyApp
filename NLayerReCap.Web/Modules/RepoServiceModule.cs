using Autofac;
using NLayerReCap.Core.Repository;
using NLayerReCap.Core.Services;
using NLayerReCap.Core.UnitOfWorks;
using NLayerReCap.Repository;
using NLayerReCap.Repository.Repositories;
using NLayerReCap.Repository.UnitOfWorks;
using NLayerReCap.Service.Mapping;
using NLayerReCap.Service.Services;
using System.Reflection;
using Module = Autofac.Module;        // TTT

namespace NLayerReCap.Web.Modules
{
    public class RepoServiceModule : Module  // HHH
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var webAssembly=Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(webAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(webAssembly,repoAssembly,serviceAssembly)
                .Where(x=>x.Name.EndsWith("Service")).AsImplementedInterfaces() .InstancePerLifetimeScope();

        }
    }
}

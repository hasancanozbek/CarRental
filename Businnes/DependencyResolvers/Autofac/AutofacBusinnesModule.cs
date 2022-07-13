
using Autofac;
using Businnes.Abstracts;
using Businnes.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Module = Autofac.Module;

namespace Businnes.DependencyResolvers.Autofac
{
    public class AutofacBusinnesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarRepository>().As<ICarRepository>().SingleInstance();

        }
    }
}

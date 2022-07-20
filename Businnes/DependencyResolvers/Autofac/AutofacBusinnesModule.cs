﻿
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinnesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarRepository>().As<ICarRepository>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerRepository>().As<ICustomerRepository>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandRepository>().As<IBrandRepository>().SingleInstance();

            builder.RegisterType<GearTypeManager>().As<IGearTypeService>().SingleInstance();
            builder.RegisterType<EfGearTypeRepository>().As<IGearTypeRepository>().SingleInstance();

            builder.RegisterType<FuelTypeManager>().As<IFuelTypeService>().SingleInstance();
            builder.RegisterType<EfFuelTypeRepository>().As<IFuelTypeRepository>().SingleInstance();

            builder.RegisterType<ColourManager>().As<IColourService>().SingleInstance();
            builder.RegisterType<EfColourRepository>().As<IColourRepository>().SingleInstance();

            builder.RegisterType<RentDetailManager>().As<IRentDetailService>().SingleInstance();
            builder.RegisterType<EfRentDetailRepository>().As<IRentDetailRepository>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

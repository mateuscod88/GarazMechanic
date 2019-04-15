using Autofac;
using Autofac.Integration.Mvc;
using BL.Brand.Service;
using BL.Car.Services;
using BL.Engine.Service;
using BL.Model.Service;
using BL.Owner.Service;
using DB;
using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebGaraz
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CarHistoryContext>()
                   .As<IDatabaseService>();
            builder.RegisterType<GetAllCarQuery>()
                   .As<IGetAllCars>()
                   .InstancePerDependency();
            builder.RegisterType<BrandService>()
                   .As<IBrandService>();
            builder.RegisterType<ModelService>()
                   .As<IModelService>();
            builder.RegisterType<EngineService>()
                   .As<IEngineService>();
            builder.RegisterType<OwnerService>()
                   .As<IOwnerService>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

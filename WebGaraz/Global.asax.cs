using Autofac;
using Autofac.Integration.Mvc;
using BL.Car.Services;
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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

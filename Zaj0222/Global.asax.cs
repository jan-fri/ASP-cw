using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Zaj0222.Models;
using Zaj0222.ViewModel;

namespace Zaj0222
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.CreateMap<Customers, CustomerViewModel>();
            Mapper.CreateMap<CustomerViewModel, Customers>();
        }
    }
}

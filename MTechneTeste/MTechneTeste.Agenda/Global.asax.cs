using MTechneTeste.Application.AutoMapper;
using MTechneTeste.Domain.IOC;
using System.Web.Mvc;
using System.Web.Routing;

namespace MTechneTeste.Agenda
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MTechneContainer.Container = ContainerConfig.Configure();
            AutoMapperConfig.RegisterMappings();
        }
    }
}

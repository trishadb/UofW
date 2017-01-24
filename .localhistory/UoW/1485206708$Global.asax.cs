using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using UoW.App_Start;
using UoW.Data;

namespace UoW
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {


            // Init database
            System.Data.Entity.Database.SetInitializer(new StoreSeedData());

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IoCConfig.RegisterDependencies();
        }
    }
}

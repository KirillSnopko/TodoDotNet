using System.Web.Mvc;
using System.Web.Routing;
using TodoApp.App_Start;

namespace TodoApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Log4netConfig.configure();
            UnityConfig.RegisterComponents();





        }
    }
}

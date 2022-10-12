using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Obligatorio_1_prog2
{
    public class Global : HttpApplication
    {
        public static TransitoMaritimo transitoMaritimo = new TransitoMaritimo();
        void Application_Start(object sender, EventArgs e)
        {
            Persistencia.leerDatos();
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_End(object sender, EventArgs e)
        {
            Persistencia.guardarDatos();

        }
    }
}
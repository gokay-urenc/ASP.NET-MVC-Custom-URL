using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_21_Custom_URL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); // Bunu ekledik. Attribute kullanılabilmesi için var.

            routes.MapRoute(
                name: "products",
                url: "SeciliKategori/{*name}",
                defaults: new { controller = "Home", action = "GetProducts" }
                ); // Bu routeyi ekledik.

            routes.MapRoute(
                name: "product",
                url: "SeciliUrun/{id}/{*name}",
                defaults: new { controller = "Home", action = "GetProduct" }
                ); // Bu routeyi ekledik.

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "GetCategories", id = UrlParameter.Optional } // Index'i GetCategories yaptık.
            );
        }
    }
}
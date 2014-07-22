using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SHEMO
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "detail wisata",
                "wisata/detail/{ID}",
                new { controller = "wisata", action = "detail" }
            );

            routes.MapRoute(
                "kategori wisata",
                "wisata/kategori/{jenisKategori}",
                new { controller = "wisata", action = "kategori" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}

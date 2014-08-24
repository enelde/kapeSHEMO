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
                "detail hotel",
                "hotel/detail/{ID}",
                new { controller = "hotel", action = "detail" }
            );

            routes.MapRoute(
                "kategori hotel",
                "hotel/kategori/{jenisKategori}",
                new { controller = "hotel", action = "kategori" }
            );

            routes.MapRoute(
                "detail rumah makan",
                "rumahmakan/detail/{ID}",
                new { controller = "rumahmakan", action = "detail" }
            );

            routes.MapRoute(
                "kategori rumah makan",
                "rumahmakan/kategori/{jenisKategori}",
                new { controller = "rumahmakan", action = "kategori" }
            );

            routes.MapRoute(
                "list menu rumah makan",
                "rumahmakan/detail/{ID}/menu",
                new { controller = "rumahmakan", action = "menu" }
            );

            routes.MapRoute(
                "detail transportasi",
                "transportasi/detail/{ID}",
                new { controller = "transportasi", action = "detail" }
            );

            routes.MapRoute(
                "kategori transportasi",
                "transportasi/kategori/{jenisKategori}",
                new { controller = "transportasi", action = "kategori" }
            );

            routes.MapRoute(
                "detail acara",
                "acara/detail/{ID}",
                new { controller = "acara", action = "detail" }
            );

            routes.MapRoute(
                "kategori acara",
                "acara/kategori/{jenisKategori}",
                new { controller = "acara", action = "kategori" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}

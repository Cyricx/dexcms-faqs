using DexCMS.Core.Infrastructure.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace DexCMS.Faqs
{
    public static class FaqsMvcRoutes
    {
        public static void CreateDefaultRoutes(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.MapRoute(
                name: "Faqs",
                url: "faqs",
                defaults: new { category = "none", controller = "FaqItems", action = "Index", urlSegment = "faqs" }
            );

        }
    }

}

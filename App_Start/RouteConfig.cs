using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace erp
{
    // GetDataDepartmentAll
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "main",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
          );

            // EditB

            routes.MapRoute(
            name: "StoreB",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Main", action = "StoreB", id = UrlParameter.Optional }
        );


            routes.MapRoute(
              name: "EditB",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Main", action = "EditB", id = UrlParameter.Optional }
          );


          routes.MapRoute(
              name: "Stoper",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Main", action = "Stoper", id = UrlParameter.Optional }
          );




            routes.MapRoute(
              name: "GetDataBaranchByUperLevel",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Main", action = "GetDataBaranchByUperLevel", id = UrlParameter.Optional }
          );



            routes.MapRoute(
           name: "GetDataBaranchAll",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "Main", action = "GetDataBaranchAll", id = UrlParameter.Optional }
       );


            routes.MapRoute(
name: "GetDataDepartmentAll",
url: "{controller}/{action}/{id}",
defaults: new { controller = "Main", action = "GetDataDepartmentAll", id = UrlParameter.Optional }
);



            routes.MapRoute(
name: "GetDataSectionsAll",
url: "{controller}/{action}/{id}",
defaults: new { controller = "Main", action = "GetDataSectionsAll", id = UrlParameter.Optional }
);




            routes.MapRoute(
            name: "GetLincenceNamesAll",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Main", action = "GetLincenceNamesAll", id = UrlParameter.Optional }
    );




            // this is for  new departmants     StoreDepartment  GetDataSectionsAll


            routes.MapRoute(
             name: "departments",
             url: "{controller}/{action}/{id}",
            defaults: new { controller = "Department", action = "Index", id = UrlParameter.Optional }
     );



            // EditB
            routes.MapRoute(
        name: "StoreDepartment",
        url: "{controller}/{action}/{id}",
         defaults: new { controller = "Department", action = "StoreDepartment", id = UrlParameter.Optional }
   );




         routes.MapRoute(
        name: "StoperD",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Department", action = "StoperD", id = UrlParameter.Optional }
        );



             routes.MapRoute(
            name: "EditD",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Department", action = "EditD", id = UrlParameter.Optional }
            );





            routes.MapRoute(
          name: "section",
          url: "{controller}/{action}/{id}",
         defaults: new { controller = "section", action = "Index", id = UrlParameter.Optional }
  );




            routes.MapRoute(
name: "StoreSection",
url: "{controller}/{action}/{id}",
defaults: new { controller = "section", action = "StoreSection", id = UrlParameter.Optional });



            //  uint
            routes.MapRoute(
       name: "EditS",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "section", action = "EditS", id = UrlParameter.Optional }
       );




            routes.MapRoute(
            name: "uint",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "uint", action = "Index", id = UrlParameter.Optional }
);



                    routes.MapRoute(
           name: "StoreU",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "uint", action = "StoreU", id = UrlParameter.Optional }
        );




        routes.MapRoute(
        name: "EditU",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "uint", action = "EditU", id = UrlParameter.Optional });







         routes.MapRoute(
          name: "employee",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "employee", action = "Index", id = UrlParameter.Optional });



         routes.MapRoute(
        name: "StoreEmployee",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "employee", action = "StoreEmployee", id = UrlParameter.Optional });





        }
    }
}

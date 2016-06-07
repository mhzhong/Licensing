using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using DataLayer;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ProductTypes",
                routeTemplate: "api/ProductType/{id}",
                defaults: new { controller = "ProductType", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "LicensesFilteredByProductTypes",
                routeTemplate: "api/ProductType/{productTypeId}/Licenses",
                defaults: new { controller = "License", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "Licenses",
                routeTemplate: "api/License/{id}",
                defaults: new { controller = "License", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "LicenseLookUp",
                routeTemplate: "api/LicenseLookUp/{name}",
                defaults: new { controller = "LicenseLookUp", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "Authorization",
                routeTemplate: "api/Authorization/{id}",
                defaults: new { controller = "Authorization", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "ProductFamily",
                routeTemplate: "api/ProductFamily/{id}",
                defaults: new { controller = "ProductFamily", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "Activation",
                routeTemplate: "api/Activation/{id}",
                defaults: new { controller = "Activation", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
               name: "Application",
               routeTemplate: "api/Application/{id}",
               defaults: new { controller = "Application", id = RouteParameter.Optional }
               );
            
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));


        }
    }
}

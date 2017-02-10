using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using ScenarioSim.ScenarioManagementService.Areas.HelpPage;
using ScenarioSim.Infrastructure.JsonNetSerializer;

namespace ScenarioSim.ScenarioManagementService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.SetDocumentationProvider(new XmlDocumentationProvider(
                HttpContext.Current.Server.MapPath("~/App_Data/ScenarioSim.ScenarioManagementService.xml")));

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new WriteablePropertiesOnlyResolver();
        }
    }
}

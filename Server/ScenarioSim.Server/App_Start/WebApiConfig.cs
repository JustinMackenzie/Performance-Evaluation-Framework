using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace ScenarioSim.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new WriteablePropertiesOnlyResolver();
            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;*/
        }
    }
}

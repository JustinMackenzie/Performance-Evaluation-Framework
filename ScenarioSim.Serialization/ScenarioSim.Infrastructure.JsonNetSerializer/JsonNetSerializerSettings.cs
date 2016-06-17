using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ScenarioSim.Infrastructure.JsonNetSerializer
{
    internal static class JsonNetSerializerSettings
    {
        public static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            ContractResolver = new WriteablePropertiesOnlyResolver(),
            TypeNameHandling = TypeNameHandling.Objects
        };
    }
}

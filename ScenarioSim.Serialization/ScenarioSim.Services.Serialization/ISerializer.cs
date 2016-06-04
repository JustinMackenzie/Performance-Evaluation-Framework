using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Services.Serialization
{
    public interface ISerializer
    {
        string Serialize<T>(T value);
        T Deserialize<T>(string value);
    }
}

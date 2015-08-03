using Ninject.Modules;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Infrastructure.XmlSerialization;

namespace ScenarioSim.Infrastructure.DependencyResolution
{
    public class SerializationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IFileSerializer<>)).To(typeof(XmlFileSerializer<>));
        }
    }
}

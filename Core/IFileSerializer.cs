using System;
namespace ScenarioSim.Core
{
    public interface IFileSerializer<T>
    {
        T Deserialize(string filename);
        void Serialize(string filename, T value);
    }
}

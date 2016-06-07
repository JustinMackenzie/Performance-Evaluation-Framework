using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Save(User user);
        void Remove(int id);
    }
}

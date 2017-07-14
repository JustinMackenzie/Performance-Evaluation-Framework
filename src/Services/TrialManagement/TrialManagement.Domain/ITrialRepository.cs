using System;
using TrialManagement.Domain.SeedWork;

namespace TrialManagement.Domain
{
    public interface ITrialRepository : IRepository<Trial>
    {
        Trial Get(Guid id);

        void Add(Trial trial);
    }
}

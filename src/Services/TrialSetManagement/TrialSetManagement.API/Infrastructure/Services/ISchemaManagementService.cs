using System;
using System.Threading.Tasks;
using TrialSetManagement.API.Application.Queries;

namespace TrialSetManagement.API.Infrastructure.Services
{
    public interface ISchemaManagementService
    {
        Task<ScenarioQueryDto> GetScenario(Guid id);
    }
}
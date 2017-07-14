using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Application.Queries
{
    public class TrialSetQueries : ITrialSetQueries
    {
        private readonly ITrialSetRepository _trialSetRepository;

        private readonly IScenarioRepository _scenarioRepository;

        public TrialSetQueries(ITrialSetRepository trialSetRepository, IScenarioRepository scenarioRepository)
        {
            _trialSetRepository = trialSetRepository;
            _scenarioRepository = scenarioRepository;
        }

        public IEnumerable<TrialSet> GetAllTrialSets()
        {
            IEnumerable<TrialSet> trialSet = this._trialSetRepository.GetAll();
            return trialSet;
        }

        public TrialSetDto GetTrialSetById(Guid id)
        {
            TrialSet trialSet = this._trialSetRepository.Get(id);
            TrialSetDto dto = new TrialSetDto
            {
                Id = trialSet.Id,
                Name = trialSet.Name,
                Scenarios = this._scenarioRepository.GetScenarios(trialSet.ScenarioIds.ToList())
            };
            return dto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.API.Query.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ITrialSetQueries" />
    public class TrialSetQueries : ITrialSetQueries
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialSetQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetQueries"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TrialSetQueries(ITrialSetQueryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all trial sets.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TrialSetQueryDto>> GetAllTrialSets()
        {
            IEnumerable<TrialSetQueryDto> trialSetCollection = await this._repository.GetAll();
            return trialSetCollection;
        }

        /// <summary>
        /// Gets the trial set by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TrialSetQueryDto> GetTrialSetById(Guid id)
        {
            TrialSetQueryDto trialSet = await this._repository.GetTrialSet(id);
            return trialSet;
        }
    }
}

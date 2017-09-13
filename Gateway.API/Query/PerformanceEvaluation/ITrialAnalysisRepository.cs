using System.Linq;
using System.Threading.Tasks;

namespace Gateway.API.Query.PerformanceEvaluation
{
    public interface ITrialAnalysisRepository
    {
        /// <summary>
        /// Adds the specified analysis.
        /// </summary>
        /// <param name="analysis">The analysis.</param>
        /// <returns></returns>
        Task Add(TrialAnalysis analysis);

        /// <summary>
        /// Gets the trial analysis.
        /// </summary>
        /// <returns></returns>
        IQueryable<TrialAnalysis> GetTrialAnalysis();
    }
}
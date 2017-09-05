using System.Threading.Tasks;

namespace PerformanceEvaluation.API.IntegrationEvents.EventHandlers
{
    public interface ITrialAnalysisRepository
    {
        /// <summary>
        /// Adds the specified analysis.
        /// </summary>
        /// <param name="analysis">The analysis.</param>
        /// <returns></returns>
        Task Add(TrialAnalysis analysis);
    }
}
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PerformanceEvaluation.API.IntegrationEvents.EventHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PerformanceEvaluation.API.IntegrationEvents.EventHandlers.ITrialAnalysisRepository" />
    public class TrialAnalysisRepository : ITrialAnalysisRepository
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialAnalysisRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public TrialAnalysisRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// Adds the specified analysis.
        /// </summary>
        /// <param name="analysis">The analysis.</param>
        /// <returns></returns>
        public async Task Add(TrialAnalysis analysis)
        {
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                await connection.OpenAsync();
                string query = @"INSERT INTO trials VALUES (@TrialId, @UserId, @Distance, @Width, @Speed);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TrialId", analysis.TrialId);
                    command.Parameters.AddWithValue("@UserId", analysis.UserId);
                    command.Parameters.AddWithValue("@Distance", analysis.Distance);
                    command.Parameters.AddWithValue("@Width", analysis.Width);
                    command.Parameters.AddWithValue("@Speed", analysis.Milliseconds);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}